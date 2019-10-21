using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField] GameObject explosion;
    [SerializeField] AudioClip sound;
    // Start is called before the first frame update

    public void Explode()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    public void KillSelf()
    {
        Destroy(gameObject);
    }
}
