using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class profile_Out : MonoBehaviour
{
	[Header("это для текстов ПОДРОБНЕЕ")]
	public TextMeshProUGUI map_TMP_MORE_Y;
	public TextMeshProUGUI map_TMP_MORE_N;
	
	[Header("для ответов ном1")]
	public Image[] toggle_1_Img = new Image[5];
	
	[Header("для ответов ном1")]
	public Image[] toggle_2_Img = new Image[5];
	
	[Header("для истории")]
	public Image[] history_toggle_Img = new Image[5];
	
	public Sprite sprite_YES;
	public Sprite sprite_NO;
	
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
	
	public int test_obsiy_1 = 0;
	public int test_obsiy_2 = 0;
	
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
		
		test_obsiy_1 = PlayerPrefs.GetInt("Test_obsiy_1");
		test_obsiy_2 = PlayerPrefs.GetInt("Test_obsiy_2");
		
		walk_map = PlayerPrefs.GetInt("Walk_map");
		
		history = PlayerPrefs.GetInt("History");
		
		score_test = test_kontora_1+test_kontora_2+test_krichniy_1+test_krichniy_2+test_kuznitsa_1+test_kuznitsa_2+test_domna_1+test_domna_2+test_obsiy_1+test_obsiy_2;
		
		history_TMP.text = "Можно изучить материал по 5и воссозданным историческим зданиям. Вы изучили " + history + ".";
		map_TMP.text = "Всего можно посетить 4 воссозданных исторических здания. Вы посмотрели " + walk_map + ".";
		test_TMP.text = "Всего можно выполнить 10 тестов на знание истории города. Вы успешно прошли " + score_test + ".";
		
		OutWalkMore();
		OutHistoryMore();
		OutTestMore();
		
		history_IMG.fillAmount = (1f/5f) * history;
		map_IMG.fillAmount = (1f/4f) * walk_map;
		test_IMG.fillAmount = (1f/10f) * score_test;
		
		if(score_test == 10)
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
	
	public void GOD_MODE()
	{
		PlayerPrefs.SetInt ("Test_kontora_1", 1);
		PlayerPrefs.SetInt ("Test_kontora_2", 1);
		
		PlayerPrefs.SetInt("Test_krichniy_1", 1);
		PlayerPrefs.SetInt("Test_krichniy_2", 1);
		
		PlayerPrefs.SetInt("Test_kuznitsa_1", 1);
		PlayerPrefs.SetInt("Test_kuznitsa_2", 1);
		
		PlayerPrefs.SetInt("Test_domna_1", 1);
		PlayerPrefs.SetInt("Test_domna_2", 1);
		
		PlayerPrefs.SetInt("Test_obsiy_1", 1);
		PlayerPrefs.SetInt("Test_obsiy_2", 1);
		
		PlayerPrefs.SetInt("History_kontora", 1);
		PlayerPrefs.SetInt("History_krichniy", 1);
		PlayerPrefs.SetInt("History_kuznitsa", 1);
		PlayerPrefs.SetInt("History_domna", 1);
		PlayerPrefs.SetInt("History_obsiy", 1);
		
		PlayerPrefs.SetInt("Walk_map", 4);
		
		PlayerPrefs.SetInt("History", 5);
	}
	
	private void OutWalkMore()
	{		
		map_TMP_MORE_Y.text="";
		map_TMP_MORE_N.text="";
		
		if(PlayerPrefs.GetInt("Walk_kontora")==1){
			map_TMP_MORE_Y.text+=("Заводская контора\n");
		}
		else{
			map_TMP_MORE_N.text+=("Заводская контора\n");
		}
		
		if(PlayerPrefs.GetInt("Walk_krichniy")==1){
			map_TMP_MORE_Y.text+=("Кричный корпус\n");
		}
		else{
			map_TMP_MORE_N.text+=("Кричный корпус\n");
		}
		
		if(PlayerPrefs.GetInt("Walk_kuznitsa")==1){
			map_TMP_MORE_Y.text+=("Заводская кузница\n");
		}
		else{
			map_TMP_MORE_N.text+=("Заводская кузница\n");
		}
		
		if(PlayerPrefs.GetInt("Walk_domna")==1){
			map_TMP_MORE_Y.text+=("Доменный корпус\n");
		}
		else{
			map_TMP_MORE_N.text+=("Доменный корпус\n");
		}
		
		
		if(map_TMP_MORE_Y.text=="")
		{
			map_TMP_MORE_Y.text="(Таких мест нет)";
		}
		
		if(map_TMP_MORE_N.text=="")
		{
			map_TMP_MORE_N.text="(Таких мест нет)";
		}
	}
	
	private void OutHistoryMore()
	{		
		for(int i=0; i<=4; i++)
		{
			history_toggle_Img[i].sprite = sprite_NO;
		}
		
		if(PlayerPrefs.GetInt("History_kontora")==1){
			history_toggle_Img[0].sprite = sprite_YES;
		}
		
		if(PlayerPrefs.GetInt("History_krichniy")==1){
			history_toggle_Img[2].sprite = sprite_YES;
		}
		
		if(PlayerPrefs.GetInt("History_kuznitsa")==1){
			history_toggle_Img[3].sprite = sprite_YES;
		}
		
		if(PlayerPrefs.GetInt("History_domna")==1){
			history_toggle_Img[1].sprite = sprite_YES;
		}
		
		if(PlayerPrefs.GetInt("History_obsiy")==1){
			history_toggle_Img[4].sprite = sprite_YES;
		}
	}
	
	
	private void OutTestMore()
	{
		for(int i=0; i<=4; i++)
		{
			toggle_1_Img[i].sprite = sprite_NO;
			toggle_2_Img[i].sprite = sprite_NO;
		}
		
		if(PlayerPrefs.GetInt("Test_kontora_1")==1){
			toggle_1_Img[0].sprite = sprite_YES;
		}
		if(PlayerPrefs.GetInt("Test_kontora_2")==1){
			toggle_2_Img[0].sprite = sprite_YES;
		}
	
		if(PlayerPrefs.GetInt("Test_krichniy_1")==1){
			toggle_1_Img[2].sprite = sprite_YES;
		}
		if(PlayerPrefs.GetInt("Test_krichniy_2")==1){
			toggle_2_Img[2].sprite = sprite_YES;
		}
		
		
		if(PlayerPrefs.GetInt("Test_kuznitsa_1")==1){
			toggle_1_Img[3].sprite = sprite_YES;
		}
		if(PlayerPrefs.GetInt("Test_kuznitsa_2")==1){
			toggle_2_Img[3].sprite = sprite_YES;
		}
		
		
		if(PlayerPrefs.GetInt("Test_domna_1")==1){
			toggle_1_Img[1].sprite = sprite_YES;
		}
		if(PlayerPrefs.GetInt("Test_domna_1")==1){
			toggle_2_Img[1].sprite = sprite_YES;
		}
		
		if(PlayerPrefs.GetInt("Test_obsiy_1")==1){
			toggle_1_Img[4].sprite = sprite_YES;
		}
		if(PlayerPrefs.GetInt("Test_obsiy_2")==1){
			toggle_2_Img[4].sprite = sprite_YES;
		}
	}
}
