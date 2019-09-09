using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    // Start is called before the first frame update

    public void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    public void KillSelf()
    {
        Destroy(gameObject);
    }
}
