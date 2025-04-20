using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class profile_Out : MonoBehaviour
{
	[Header("это для шкалы")]
	public Image history_IMG;
	public Image map_IMG;
	public Image test_IMG;
	
	[Header("это для изменения текстов")]
	public TextMeshProUGUI history_TMP;
	public TextMeshProUGUI map_TMP;
	public TextMeshProUGUI test_TMP;
	
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
	
	int score_test;
	
	
    void Start()
    {
		GET_And_OUT();
    }

    // Update is called once per frame
    void Update()
    {
        GET_And_OUT();
    }
	
	void GET_And_OUT()
	{
		        q_1_kontora = PlayerPrefs.GetInt("Q_1_kontora");
		q_2_kontora = PlayerPrefs.GetInt("Q_2_kontora");
					
		q_1_kcichniy = PlayerPrefs.GetInt("Q_1_kcichniy");
		q_2_kcichniy = PlayerPrefs.GetInt("Q_2_kcichniy");
					
		q_1_kuznitsa = PlayerPrefs.GetInt("Q_1_kuznitsa");
		q_2_kuznitsa = PlayerPrefs.GetInt("Q_2_kuznitsa");
					
		walk_map = PlayerPrefs.GetInt("Walk_map");
		
		history = PlayerPrefs.GetInt("History");
		
		history_TMP.text = "Можно изучить материал по 3м воссозданым  историческм зданиям. Вы изучили " + history + ".";
		map_TMP.text = "Всего можно посетить 3 воссозданых  историческх здания. Вы посмотрели " + walk_map + ".";
		score_test = q_1_kontora + q_2_kontora + q_1_kcichniy + q_2_kcichniy + q_1_kuznitsa + q_2_kuznitsa;
		test_TMP.text = "Всего можно выполнить 6 тестов по знанию истории города. Вы успешно прошли " + score_test + ".";
		
		history_IMG.fillAmount = 1/3 * history;
		map_IMG.fillAmount = 1/3 * walk_map;
		test_IMG.fillAmount = 1/6 * score_test;
	}
}
