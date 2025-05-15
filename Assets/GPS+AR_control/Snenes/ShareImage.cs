using UnityEngine;
using UnityEngine.UI;

public class ShareImage : MonoBehaviour
{
    [SerializeField] private Button shareButton;

    private void Start()
    {
        shareButton.onClick.AddListener(ShareText);
    }

    public void ShareText()
    {
        string shareSubject = "Начните изучать историю своего города по-овому с Живой Историей Первоуральска!";
        string shareMessage = "https://www.rustore.ru/catalog/app/com.unity.template.ar_mobile.Cheloveki_team";

        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
        
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        intentObject.Call<AndroidJavaObject>("setType", "text/plain");
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), shareSubject);
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), shareMessage);

        AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
        
        AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Поделиться с помощью");
        currentActivity.Call("startActivity", chooser);
    }
}