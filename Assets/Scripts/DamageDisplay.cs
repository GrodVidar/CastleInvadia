using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5f, 5f), 7f);
        StartCoroutine(KillSelf());
    }

    private IEnumerator KillSelf()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
