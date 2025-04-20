using UnityEngine;
using UnityEngine.UI;

public class map_design_set : MonoBehaviour
{
    public Image MapImage;
	
    public Sprite Map_custom;
	public Sprite Map_sputnic;
	
	public void Set_New_Design_forMap()
	{
		if(MapImage.sprite != Map_custom){
			MapImage.sprite = Map_custom;
		}
		else{
			MapImage.sprite = Map_sputnic;
		}
	}
}
