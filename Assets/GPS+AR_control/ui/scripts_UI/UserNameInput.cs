using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class UserNameInput : MonoBehaviour
{
	public TMP_InputField tmpInputField;
	
    
	public void UserName_Input()
	{
		if(tmpInputField.text!="")
			PlayerPrefs.SetString("UserName", tmpInputField.text);
		else
			PlayerPrefs.SetString("UserName", PlayerPrefs.GetString("UserName"));
	}
}
