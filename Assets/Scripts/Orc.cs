using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Orc : MonoBehaviour
{
	//Configs
	float jumpVel = 18f;
    float movementSpeed = 2f;
	//States
	bool isFacingRight = true;
    bool canJump = true;
    //Waypoints
    [SerializeField] Transform[] waypoints;
    [SerializeField] Transform jumpPoints;
    int waypointIndex = 0;
    //Caches
	Player player;
	Rigidbody2D myRigidBody;
    BoxCollider2D feet;
    Transform gun;
    Weapon weapon;
    Animator animator;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject projectileParent;

    // Start is called before the first frame update
    void Start()
    {
		player = FindObjectOfType<Player>();
        feet = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        weapon = GetComponent<Weapon>();
		myRigidBody = GetComponent<Rigidbody2D>();
        gun = gameObject.transform.GetChild(0);
        InvokeRepeating("Jump", 0, 4f);
        InvokeRepeating("StartShootAnim", 0, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        Move();
        //int randNumb = Random.Range(1, 7);
        //if((feet.IsTouchingLayers(LayerMask.GetMask("Ground")) || feet.IsTouchingLayers(LayerMask.GetMask("Player"))) && randNumb % 4 == 0)
        //{
        //    Jump();
        //}
        if(Math.Round(transform.position.x,2) == Math.Round(jumpPoints.position.x, 2))
        {
            Jump();
        }
        
        if(feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            animator.SetBool("Jumping", false);
        }
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

    private void Move()
    {
        animator.SetBool("isWalking", true);
        transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, waypoints[waypointIndex].position.x, movementSpeed * Time.deltaTime), transform.position.y);
        if (transform.position.x == waypoints[waypointIndex].position.x)
        {
            waypointIndex++;

            if (waypointIndex == waypoints.Length)
            {
                waypointIndex = 0;
            }
        }
    }

    private void Flip()
	{
		transform.localScale = new Vector2(transform.localScale.x * -1, 1f);
	}

    private void Jump()
    {
        if(feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            animator.SetBool("Jumping", true);
            Vector2 JumpVelocity = new Vector2(0f, jumpVel);
            myRigidBody.velocity += JumpVelocity;
        }
    }

    private void StartShootAnim()
    {
        animator.SetTrigger("Shoot");
    }

    public void CallShoot()
    {
        var newShot = Instantiate(projectile, new Vector2(gun.transform.position.x, gun.transform.position.y), Quaternion.identity);
        newShot.transform.parent = projectileParent.transform;
    }
}
