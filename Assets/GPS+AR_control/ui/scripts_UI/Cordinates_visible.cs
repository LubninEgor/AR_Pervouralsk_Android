using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Cordinates_visible : MonoBehaviour
{
	
	public GameObject Text_GPS; 
	
	void Update()
	{
		if(Debug_ON.password == 1)
		{
			Text_GPS.SetActive(true);
		}
		
	}

}
