using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    // Синглтон-паттерн для доступа к менеджеру
    private static LoadScene _instance;
    private List<int> _sceneHistory = new List<int>();

    public static LoadScene Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("SceneHistoryManager");
                _instance = go.AddComponent<LoadScene>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    public void NextLevel(int nom)
    {
        SceneManager.LoadScene(nom);
    }

    public void RestLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenLink(string inp)
    {
        Application.OpenURL(inp);
    }

    private void Awake()
    {
        // Реализация синглтона
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
        AddCurrentSceneToHistory();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AddCurrentSceneToHistory();
    }

    private void AddCurrentSceneToHistory()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (_sceneHistory.Count == 0 || _sceneHistory[_sceneHistory.Count - 1] != currentSceneIndex)
        {
            _sceneHistory.Add(currentSceneIndex);
            Debug.Log($"Added scene {currentSceneIndex} to history. Count: {_sceneHistory.Count}");
        }
    }

    void Update()
    {
        // Обработка кнопки "Назад" на Android
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBackToPreviousScene();
        }
    }

    public void GoBackToPreviousScene()
    {
        if (_sceneHistory.Count <= 1)
        {
            Debug.LogWarning("No previous scene in history");

            // Выход из приложения, если это первая сцена
            if (Application.platform == RuntimePlatform.Android)
                Application.Quit();

            return;
        }

        // Удаляем текущую сцену из истории
        RemoveLastSceneFromHistory();

        // Загружаем предыдущую сцену
        int previousSceneIndex = _sceneHistory[_sceneHistory.Count - 1];
        SceneManager.LoadScene(previousSceneIndex);

        // Удаляем предыдущую сцену из истории
        RemoveLastSceneFromHistory();
    }

    public void RemoveLastSceneFromHistory()
    {
        if (_sceneHistory.Count > 0)
        {
            int removedScene = _sceneHistory[_sceneHistory.Count - 1];
            _sceneHistory.RemoveAt(_sceneHistory.Count - 1);
            Debug.Log($"Removed scene {removedScene} from history");
        }
    }

    public void PrintHistory()
    {
        string history = "Scene History: ";
        foreach (int sceneIndex in _sceneHistory)
        {
            history += $"{SceneManager.GetSceneByBuildIndex(sceneIndex).name} ({sceneIndex}), ";
        }
        Debug.Log(history);
    }
}