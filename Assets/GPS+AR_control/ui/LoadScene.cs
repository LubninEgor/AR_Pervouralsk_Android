using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public void NextLevel(int nom)
    {
        SceneManager.LoadScene(nom); // перемещение поо номеру сцены (номер смотреть в build profiles)
    }

    public void RestLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //рестарт сцены
    }

    public void OpenLink(string inp)
    {
        Application.OpenURL(inp); // открытие ссылки (https:///чето-там) во внешнем браузере
    }

    void Update()
    {
        // Проверяем нажатие кнопки (жеста) "Назад" на мобильном устройстве
        if (Input.GetKeyDown(KeyCode.Escape)) // Код для кнопки "Назад"
        {
            ReturnToMainScene();
        }
    }

    private void ReturnToMainScene()
    {
        // Загружаем нулевую сцену
        SceneManager.LoadScene(0);
        Debug.Log("Возврат на нулевую сцену.");
    }
}

// универсальный (полный) скрипт для перемещения между сценамии не только