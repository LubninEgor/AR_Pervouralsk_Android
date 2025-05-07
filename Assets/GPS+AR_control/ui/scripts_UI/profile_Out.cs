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
	
	[Header("пройдено тестов")]
	public int score_test = 0;
	
	public int test_kontora_1 = 0;
	public int test_kontora_2 = 0;
	
	public int test_krichniy_1 = 0;
	public int test_krichniy_2 = 0;
	
	public int test_kuznitsa_1 = 0;
	public int test_kuznitsa_2 = 0;
	
	public int test_domna_1 = 0;
	public int test_domna_2 = 0;
	
	[Header("сколько пройдено точек")]
	public int walk_map = 0;
	
	public GameObject achiv1;
	public GameObject achiv2;
	
	
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
		test_kontora_1 = PlayerPrefs.GetInt ("Test_kontora_1");
		test_kontora_2 = PlayerPrefs.GetInt ("Test_kontora_2");
		
		test_krichniy_1 = PlayerPrefs.GetInt("Test_krichniy_1");
		test_krichniy_2 = PlayerPrefs.GetInt("Test_krichniy_2");
		
		test_kuznitsa_1 = PlayerPrefs.GetInt("Test_kuznitsa_1");
		test_kuznitsa_2 = PlayerPrefs.GetInt("Test_kuznitsa_2");
		
		test_domna_1 = PlayerPrefs.GetInt("Test_domna_1");
		test_domna_2 = PlayerPrefs.GetInt("Test_domna_2");
		
		walk_map = PlayerPrefs.GetInt("Walk_map");
		
		history = PlayerPrefs.GetInt("History");
		
		score_test = test_kontora_1+test_kontora_2+test_krichniy_1+test_krichniy_2+test_kuznitsa_1+test_kuznitsa_2+test_domna_1+test_domna_2;
		
		history_TMP.text = "Можно изучить материал по 3м воссозданым  историческм зданиям. Вы изучили " + history + ".";
		map_TMP.text = "Всего можно посетить 3 воссозданых  историческх здания. Вы посмотрели " + walk_map + ".";
		
		test_TMP.text = "Всего можно выполнить 8 тестов по знанию истории города. Вы успешно прошли " + score_test + ".";
		
		history_IMG.fillAmount = (1f/4f) * history;
		map_IMG.fillAmount = (1f/4f) * walk_map;
		test_IMG.fillAmount = (1f/8f) * score_test;
		
		if(score_test == 8)
			achiv1.SetActive(false);
		else
			achiv1.SetActive(true);
		
		if(walk_map == 4)
			achiv2.SetActive(false);
		else
			achiv2.SetActive(true);
	}
	
	
	public void DelefeALL()
	{
		PlayerPrefs.DeleteAll(); // удалит все значения
	}
}
