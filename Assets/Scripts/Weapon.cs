using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Weapons indexing
 0. Stone
 1. Bow
 */

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject[] projectiles;
    [SerializeField] GameObject projectileParent;
    GameObject projectile;
    Player player;
	Inventory inventory;
	static bool hasBow = false;
    // Start is called before the first frame update
    void Start()
    {
        SetWeapon(PlayerPrefs.GetInt("ActiveWeapon"));
        player = FindObjectOfType<Player>();
		inventory = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ActiveWeapon: " + projectile.name);
		if (Input.GetKeyDown("1"))
		{
			SetWeapon(0);
			player.SetHasBow(false);
			inventory.SetActiveWeapon(0);
		}
		else if (Input.GetKeyDown("2") && inventory.GethasBow())
		{
			SetWeapon(1);
			player.SetHasBow(true);
			inventory.SetActiveWeapon(1);
		}
		else if (Input.GetKeyDown("3") && inventory.GethasBomb())
		{
			SetWeapon(2);
			player.SetHasBow(false);
			inventory.SetActiveWeapon(2);
		}
        if(player.GetCanShoot())
        {
            if(Input.GetButtonDown("Fire1"))
            {
                player.TriggerShooting();
            }
        }
    }

    public void Shoot()
    {
        projectile = projectiles[PlayerPrefs.GetInt("ActiveWeapon")];
        var newShot = Instantiate(projectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        Debug.Log("2Instantiated: " + projectile.name);
        newShot.transform.parent = projectileParent.transform;
		if(PlayerPrefs.GetInt("ActiveWeapon") == 2)
		{
			inventory.DecreaseBombs();
		}
    }

    private void SetWeapon(int weapon)
    {
		PlayerPrefs.SetInt("ActiveWeapon", weapon);
        projectile = projectiles[weapon];
        Debug.Log("activating: " + projectile.name);
    }

    public void ActivateStone()
    {
        Debug.Log("Setting to stone");
        SetWeapon(0);
        player.SetHasBow(false);
        inventory.SetActiveWeapon(0);
    }
}
