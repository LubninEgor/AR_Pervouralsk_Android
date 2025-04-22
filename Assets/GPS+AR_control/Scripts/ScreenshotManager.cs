using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
#if UNITY_ANDROID
using UnityEngine.Android;
#endif

public class ScreenshotManager : MonoBehaviour 
{
    [Header("Settings")]
    [SerializeField] private Button _screenshotButton;
    [SerializeField] private GameObject _uiToHide;
    [SerializeField] private string _galleryFolder = "AR_Gallery";

    private void Start() 
    {
        _screenshotButton.onClick.AddListener(RequestPermissionAndCapture);
    }

    private void RequestPermissionAndCapture()
    {
        #if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            StartCoroutine(TakeScreenshotAfterDelay(0.5f));
        }
        else
        {
            StartCoroutine(CaptureScreenshot());
        }
        #else
        StartCoroutine(CaptureScreenshot());
        #endif
    }

    private IEnumerator TakeScreenshotAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(CaptureScreenshot());
    }

    private IEnumerator CaptureScreenshot()
    {
        if (_uiToHide != null) _uiToHide.SetActive(false);
        yield return new WaitForEndOfFrame();

        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        if (_uiToHide != null) _uiToHide.SetActive(true);
        SaveToGallery(screenshot);
        Destroy(screenshot);
    }

    private void SaveToGallery(Texture2D screenshot)
    {
        byte[] bytes = screenshot.EncodeToPNG();
        string fileName = $"AR_{System.DateTime.Now:yyyyMMdd_HHmmss}.png";

        #if UNITY_ANDROID
        // Исправлено: убрана переменная permission
        NativeGallery.SaveImageToGallery(
            bytes,
            _galleryFolder,
            fileName,
            (success, path) => Debug.Log(success ? $"Saved to: {path}" : "Save failed!")
        );
        #else
        string path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllBytes(path, bytes);
        Debug.Log($"Saved to: {path}");
        #endif
    }
}