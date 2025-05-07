using UnityEngine;

public class Script_merger : MonoBehaviour
{
	public GameObject Kontora;
	public GameObject Kuznica;
	public GameObject Krichniy;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Load.Building_for_viev == 4)
		{
			Kontora.SetActive(true);
			Kuznica.SetActive(false);
			Krichniy.SetActive(false);
		}
		
		if(Load.Building_for_viev == 5 || Load.Building_for_viev == 10)
		{
			Kontora.SetActive(false);
			Kuznica.SetActive(true);
			Krichniy.SetActive(false);
		}
		
		if(Load.Building_for_viev == 6)
		{
			Kontora.SetActive(false);
			Kuznica.SetActive(false);
			Krichniy.SetActive(true);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
}
