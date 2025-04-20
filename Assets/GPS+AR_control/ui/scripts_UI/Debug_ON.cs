using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Debug_ON : MonoBehaviour
{
    public GameObject Plane_Register;
	public GameObject Text_GPS; 
	
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
		if(tmpInputField.text == "UralStrong")
		{
			Text_GPS.SetActive(true);
			Plane_Register.SetActive(false);
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
