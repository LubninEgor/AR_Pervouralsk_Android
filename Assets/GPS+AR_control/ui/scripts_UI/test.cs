using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class test : MonoBehaviour
{
	public Color Color_Main;
	public Color Color_Correct;
	public Color Color_In_Correct;
	
	public Toggle Correct_ANS;
	
	public Toggle UnCorrect_ANS_1;
	public Toggle UnCorrect_ANS_2;
	
    public void Check_Ans(string name_test)
	{
		if(Correct_ANS.isOn)
		{
			Correct_ANS.GetComponent<Image>().color = Color_Correct;
			UnCorrect_ANS_1.GetComponent<Image>().color = Color_Main;
			UnCorrect_ANS_2.GetComponent<Image>().color = Color_Main;
			Set_score(name_test);
		}
		
		else if(UnCorrect_ANS_1.isOn)
		{
			UnCorrect_ANS_1.GetComponent<Image>().color = Color_In_Correct;
			Correct_ANS.GetComponent<Image>().color = Color_Main;
			UnCorrect_ANS_2.GetComponent<Image>().color = Color_Main;
		}
		
		else if(UnCorrect_ANS_2.isOn)
		{
			UnCorrect_ANS_2.GetComponent<Image>().color = Color_In_Correct;
			Correct_ANS.GetComponent<Image>().color = Color_Main;
			UnCorrect_ANS_1.GetComponent<Image>().color = Color_Main;
		}
	}
	
	void Set_score(string name_test)
	{
		if(name_test == "kontora1")
			PlayerPrefs.SetInt("Test_kontora_1", 1);
		if(name_test == "kontora2")
			PlayerPrefs.SetInt("Test_kontora_2", 1);
		
		
		if(name_test == "krichniy1")
			PlayerPrefs.SetInt("Test_krichniy_1", 1);
		if(name_test == "krichniy2")
			PlayerPrefs.SetInt("Test_krichniy_2", 1);
		
		
		if(name_test == "kuznitsa1")
			PlayerPrefs.SetInt("Test_kuznitsa_1", 1);
		if(name_test == "kuznitsa2")
			PlayerPrefs.SetInt("Test_kuznitsa_2", 1);
		
		if(name_test == "domna1")
			PlayerPrefs.SetInt("Test_domna_1", 1);
		if(name_test == "domna2")
			PlayerPrefs.SetInt("Test_domna_2", 1);
		
	}
}
