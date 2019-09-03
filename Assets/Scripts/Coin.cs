using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    int value;
    Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        value = Random.Range(1, 6);
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(value<3)
        {
            animator.SetBool("Bronze", true);
        }
        else if(value == 3 || value == 4)
        {
            animator.SetBool("Silver", true);
        }
        else
        {
            animator.SetBool("Gold", true);
        }        
    }

    public int GetValue()
    {
        return value;
    }
}
