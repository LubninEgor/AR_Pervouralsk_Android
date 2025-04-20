using UnityEngine;

public class on_off : MonoBehaviour
{
    public GameObject GO;
	
	public void ONOFF()
	{
		if(GO.activeSelf)
		{
			GO.SetActive(false);
		}
		else
		{
			GO.SetActive(true);
		}
	}
}
