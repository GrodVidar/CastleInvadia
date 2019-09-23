using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{
	//Configs
	float jumpVel = 10f;
	//States
	bool isFacingRight = true;
	//Caches
	Player player;
	Rigidbody2D myRigidBody;
    BoxCollider2D feet;
    // Start is called before the first frame update
    void Start()
    {
		player = FindObjectOfType<Player>();
        feet = GetComponent<BoxCollider2D>();
		myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
		InvokeRepeating("Jump", 0, 8);
		
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
		bool isTouchingGround = feet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        Vector2 JumpVelocity = new Vector2(0f, jumpVel);
        if(!isTouchingGround)
        {
            myRigidBody.velocity += JumpVelocity;
        }
		else
		{
			myRigidBody.velocity -= JumpVelocity;
		}
    }
}
