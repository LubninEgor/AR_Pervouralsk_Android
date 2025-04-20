using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Score : MonoBehaviour
{
	[Header("пройдено истории")]
	public int history = 0;
	
	[Header("качество ответов на контору")]
	public int q_1_kontora = 0;
	public int q_2_kontora = 0;
	
	[Header("качество ответов на кричный")]
	public int q_1_kcichniy = 0;
	public int q_2_kcichniy = 0;
	
	[Header("качество ответов на кузницу")]
	public int q_1_kuznitsa = 0;
	public int q_2_kuznitsa = 0;
	
	[Header("сколько пройдено точек")]
	public int walk_map = 0;
	
	
    void Start()
    {
        q_1_kontora = PlayerPrefs.GetInt("Q_1_kontora");
		q_2_kontora = PlayerPrefs.GetInt("Q_2_kontora");
					
		q_1_kcichniy = PlayerPrefs.GetInt("Q_1_kcichniy");
		q_2_kcichniy = PlayerPrefs.GetInt("Q_2_kcichniy");
					
		q_1_kuznitsa = PlayerPrefs.GetInt("Q_1_kuznitsa");
		q_2_kuznitsa = PlayerPrefs.GetInt("Q_2_kuznitsa");
					
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
	//PlayerPrefs.DeleteAll(); // удалит все значения
}
