using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Score : MonoBehaviour
{
	[Header("пройдено истории")]
	public int history = 0;
	
	[Header("сколько пройдено тестов")]
	public int score_test = 0;
	
	[Header("сколько пройдено точек")]
	public int walk_map = 0;
	
	
    void Start()
    {
		walk_map = PlayerPrefs.GetInt("Walk_map");
		
		history = PlayerPrefs.GetInt("History");
    }

	
	public void Set_History(int nom_history)
	{
		if(nom_history == 1)
			PlayerPrefs.SetInt("History_kontora", 1);
		
		if(nom_history == 2)
			PlayerPrefs.SetInt("History_krichniy", 1);
		
		if(nom_history == 3)
			PlayerPrefs.SetInt("History_kuznitsa", 1);
		PlayerPrefs.Save();
		
		history = PlayerPrefs.GetInt("History_kontora") + PlayerPrefs.GetInt("History_krichniy") + PlayerPrefs.GetInt("History_kuznitsa");
		PlayerPrefs.SetInt("History", history);
		PlayerPrefs.Save();
		
	}
	
	public void Set_Map()
	{
		
		if(Load.Building_for_viev == 4)
			PlayerPrefs.SetInt("Walk_kontora", 1);
		
		if(Load.Building_for_viev == 6)
			PlayerPrefs.SetInt("Walk_krichniy", 1);
		
		if(Load.Building_for_viev == 5)
			PlayerPrefs.SetInt("Walk_kuznitsa", 1);
		PlayerPrefs.Save();
		
		walk_map = PlayerPrefs.GetInt("Walk_kontora") + PlayerPrefs.GetInt("Walk_krichniy") + PlayerPrefs.GetInt("Walk_kuznitsa");
		PlayerPrefs.SetInt("Walk_map", walk_map);
		PlayerPrefs.Save();
		
	}
	
	
	public void DelefeALL()
	{
		PlayerPrefs.DeleteAll(); // удалит все значения
	}
	
}
