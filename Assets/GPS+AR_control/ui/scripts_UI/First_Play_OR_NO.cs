using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class First_Play_OR_NO : MonoBehaviour
{
	
	public GameObject NoFirstIn;
	public TextMeshProUGUI Name_TMP;
    
    void Start()
    {
        if(PlayerPrefs.GetInt("Play")>=1)
		{
			NoFirstIn.SetActive(true);
			Name_TMP.text = "Привет,"+ "\n"+PlayerPrefs.GetString("UserName")+" !";
		}
		else
		{
			NoFirstIn.SetActive(false);
		}
    }
}
