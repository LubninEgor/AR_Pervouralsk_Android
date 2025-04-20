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
		score_test = PlayerPrefs.GetInt("Test");
					
		walk_map = PlayerPrefs.GetInt("Walk_map");
		
		history = PlayerPrefs.GetInt("History");
    }

	
	public void Set_History()
	{
		history+=1;
		if(history >3)
			history = 3;
		PlayerPrefs.SetInt("History", history);
		PlayerPrefs.Save();
		
	}
	
	public void Set_Map()
	{
		walk_map+=1;
		if(walk_map >3)
			walk_map = 3;
		PlayerPrefs.SetInt("Walk_map", walk_map);
		PlayerPrefs.Save();
		
	}
	
	
    void Update()
    {
        
    }
	public void DelefeALL()
	{
		PlayerPrefs.DeleteAll(); // удалит все значения
	}
	
}
