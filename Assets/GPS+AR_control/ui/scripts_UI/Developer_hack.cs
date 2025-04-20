using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class Developer_hack : MonoBehaviour
{
	
	public TextMeshProUGUI Name_TMP;
	public Button BT_delete;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		if (Debug_ON.password == 1)
		{
			Name_TMP.text = "Разработчик";
			BT_delete.interactable = true;
			
		}
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Debug_ON.password == 1)
		{
			Name_TMP.text = "Разработчик";
			BT_delete.interactable = true;
		}
    }
}
