using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadBigTexture : MonoBehaviour
{
    public string imagePath1 = "image1.png";
    public string imagePath2 = "image2.png";
    public Button switchButton;

    private Texture2D texture1;
    private Texture2D texture2;
    private bool isFirstImage = true;
    private Renderer objectRenderer;
    private RawImage rawImageComponent;

    void Start()
    {
        // Инициализация компонентов
        objectRenderer = GetComponent<Renderer>();
        rawImageComponent = GetComponent<RawImage>();

        // Загрузка обеих текстур
        texture1 = LoadTexture(imagePath1);
        texture2 = LoadTexture(imagePath2);

        // Установка начальной текстуры
        SetTexture(texture1);

        // Настройка кнопки
        if (switchButton != null)
        {
            switchButton.onClick.AddListener(SwitchImage);
        }
    }

    Texture2D LoadTexture(string path)
    {
        string fullPath = Path.Combine(Application.streamingAssetsPath, path);
        if (!File.Exists(fullPath))
        {
            Debug.LogError("File not found: " + fullPath);
            return null;
        }

        byte[] bytes = File.ReadAllBytes(fullPath);
        Texture2D loadedTexture = new Texture2D(2, 2);
        loadedTexture.LoadImage(bytes);
        return loadedTexture;
    }

    void SetTexture(Texture2D texture)
    {
        if (texture == null) return;

        if (objectRenderer != null)
        {
            objectRenderer.material.mainTexture = texture;
        }
        else if (rawImageComponent != null)
        {
            rawImageComponent.texture = texture;
        }
        else
        {
            Debug.LogError("No Renderer or RawImage component found!");
        }
    }

    public void SwitchImage()
    {
        if (texture1 == null || texture2 == null)
        {
            Debug.LogError("Textures not loaded!");
            return;
        }

        isFirstImage = !isFirstImage;
        SetTexture(isFirstImage ? texture1 : texture2);
    }
}