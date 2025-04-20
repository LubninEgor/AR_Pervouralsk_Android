using UnityEngine;
using UnityEngine.UI;

public class Size_map : MonoBehaviour
{
    public GameObject MapUI;
	public Slider zoom;
	
	void Update()
	{
		MapUI.transform.localScale = new Vector3(zoom.value/2, zoom.value/2, zoom.value/2);
	}
}
