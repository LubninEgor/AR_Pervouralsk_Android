using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
	public static int Building_for_viev;
	
    public void SetNextLevel(int level)
    {
		Building_for_viev = level;
    }
	
	public void Next()
    {
        SceneManager.LoadScene(Building_for_viev);
    }
	
	
	
	
}

// универсальный (полный) скрипт для перемещения между сценамии не только