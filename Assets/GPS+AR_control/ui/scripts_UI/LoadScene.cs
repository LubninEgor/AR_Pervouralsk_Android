using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    // Синглтон-паттерн для доступа к менеджеру

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

}