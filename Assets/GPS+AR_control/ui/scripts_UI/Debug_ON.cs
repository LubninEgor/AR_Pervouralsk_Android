using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Debug_ON : MonoBehaviour
{
    public GameObject Plane_Register;
	//public GameObject Text_GPS; 
	public static int password;
	
	public TMP_InputField tmpInputField;
	
	public void ONOFF()
	{
		if(Plane_Register.activeSelf)
		{
			Plane_Register.SetActive(false);
		}
		else
		{
			Plane_Register.SetActive(true);
		}
		
	}
	
	public void Chek_Password()
	{
		if(tmpInputField.text == "vrar456456456")
		{
			//Text_GPS.SetActive(true);
			//Plane_Register.SetActive(false);
			password = 1;
			SceneManager.LoadScene(1);
		}
		else
		{
			PlayVibration();
		}
	}
	

    public void PlayVibration()
    {
        Handheld.Vibrate();
    }

}
