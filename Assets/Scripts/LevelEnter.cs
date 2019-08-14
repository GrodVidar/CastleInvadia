using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnter : MonoBehaviour
{
    [SerializeField] Sprite closedDoor;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForASecond());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitForASecond()
    {
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().sprite = closedDoor;
    }

}
