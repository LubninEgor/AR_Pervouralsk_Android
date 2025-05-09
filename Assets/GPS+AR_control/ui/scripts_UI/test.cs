using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class test : MonoBehaviour
{
	public Color Color_Main;
	public Color Color_Correct;
	public Color Color_In_Correct;
	
	public Transform[] targets = new Transform[3]; // Перетащите все ответы сюда
	
	public Toggle Correct_ANS;
	public Toggle UnCorrect_ANS_1;
	public Toggle UnCorrect_ANS_2;
	
	
	void Start()
    {
        // Собираем позиции
        List<Vector3> positions = new List<Vector3>
        {
            targets[0].position,
            targets[1].position,
            targets[2].position
        };

        // Перемешиваем позиции
        Shuffle(positions);

        // Присваиваем новые позиции
        for (int i = 0; i < 3; i++)
        {
            targets[i].position = positions[i];
        }
    }

    // Алгоритм Фишера-Йетса для перемешивания
    private void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
	

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
