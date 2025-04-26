using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem; // Add this at the top
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Back_android : MonoBehaviour
{
	public GameObject Window;
    void Update()
    {
        // Проверяем нажатие кнопки (жеста) "Назад" на мобильном устройстве
        if (Input.GetKeyDown(KeyCode.Escape)) // Код для кнопки "Назад"
        {
			Window.SetActive(false);
        }
    }
}