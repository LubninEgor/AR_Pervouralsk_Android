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
	
    public void Check_Ans()
	{
		if(Correct_ANS.isOn)
		{
			Correct_ANS.GetComponent<Image>().color = Color_Correct;
		}
		
		else if(UnCorrect_ANS_1.isOn)
		{
			UnCorrect_ANS_1.GetComponent<Image>().color = Color_In_Correct;
			Correct_ANS.GetComponent<Image>().color = Color_Correct;
		}
		
		else if(UnCorrect_ANS_2.isOn)
		{
			UnCorrect_ANS_2.GetComponent<Image>().color = Color_In_Correct;
			Correct_ANS.GetComponent<Image>().color = Color_Correct;
		}
	}
	
}
