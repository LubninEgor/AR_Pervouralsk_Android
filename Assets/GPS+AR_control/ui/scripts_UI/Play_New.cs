using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Play_New : MonoBehaviour
{
	
	public void Score_Play_UP()
	{
		PlayerPrefs.SetInt("Play", PlayerPrefs.GetInt("Play")+1);
	}
}
