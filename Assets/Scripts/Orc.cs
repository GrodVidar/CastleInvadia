using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{
	//States
	bool isFacingRight = true;
	//Caches
	Player player;
    BoxCollider2D feet;
    // Start is called before the first frame update
    void Start()
    {
		player = FindObjectOfType<Player>();
        feet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();

    }

    private void LookAtPlayer()
    {
        if(player.transform.position.x < transform.position.x && isFacingRight)
		{
			Flip();
			isFacingRight = false;
		}
		else if(player.transform.position.x > transform.position.x && !isFacingRight)
		{
			Flip();
			isFacingRight = true;
		}
    }

	private void Flip()
	{
		transform.localScale = new Vector2(transform.localScale.x * -1, 1f);
	}

    private void Jump()
    {
        if(feet.IsTouchingLayers(LayerMask.GetMask("Groud")))
        {
            Vector2 JumpVelocity = new Vector2(0f, jumpVel);
            myRigidBody.velocity += JumpVelocity;
        }
    }
}
