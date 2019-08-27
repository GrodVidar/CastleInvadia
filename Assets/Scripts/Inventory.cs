using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	//states
	bool hasBow = false;

	//caches
	[SerializeField] GameObject[] weapons;
	[SerializeField] GameObject[] backgrounds;
    // Start is called before the first frame update
    void Start()
    {
  //     foreach(GameObject weapon in weapons)
		//{
		//	if(weapon.name != "StoneBG")
		//	{
		//		weapon.SetActive(false);
		//	}
		//}
		backgrounds[0].SetActive(true); // sets the Stone set to active in the beginning of each scene.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SetBowAquired()
	{
		foreach(GameObject weapon in weapons)
		{
			if(weapon.name == "ArrowBG")
			{
				weapon.SetActive(true);
				hasBow = true;
			}
		}
	}

	public bool GethasBow()
	{
		return hasBow;
	}

	public void SetActiveWeapon(int index)
	{
		foreach(GameObject background in backgrounds)
		{
			background.SetActive(false);
		}
		backgrounds[index].SetActive(true);
	}
}
