using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class Developer_hack : MonoBehaviour
{
	
	public TextMeshProUGUI Name_TMP;
	public Button BT_delete;
	public Button BT_GOD;
	public Button BT_Exit;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		if (Debug_ON.password == 1)
		{
			Name_TMP.text = "Разработчик";
			BT_delete.interactable = true;
			BT_GOD.interactable = true;
		}
		else if(PlayerPrefs.GetString("UserName")!="")
			Name_TMP.text = PlayerPrefs.GetString("UserName");
		else
			Name_TMP.text = "Пользователь";
        
    }
	
	public void Exit_Developer_Account()
	{
		Debug_ON.password = 0;
	}

    
    void Update()
    {
        if (Debug_ON.password == 1)
		{
			Name_TMP.text = "Разработчик";
			BT_delete.interactable = true;
			BT_GOD.interactable = true;
			BT_Exit.interactable = true;
		}
		
		else
		{
			if(PlayerPrefs.GetString("UserName")!="")
				Name_TMP.text = PlayerPrefs.GetString("UserName");
			else
				Name_TMP.text = "Пользователь";
			
			BT_delete.interactable = false;
			BT_GOD.interactable = false;
			BT_Exit.interactable = false;
		}
    }
}
