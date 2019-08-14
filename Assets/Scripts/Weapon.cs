using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject[] projectiles;
    [SerializeField] GameObject projectileParent;
    GameObject projectile;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        SetWeapon(0);
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
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
        var newShot = Instantiate(projectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        newShot.transform.parent = projectileParent.transform;
    }

    public void SetWeapon(int weapon)
    {
        projectile = projectiles[weapon];        
    }
}
