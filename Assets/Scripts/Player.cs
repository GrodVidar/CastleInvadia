using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    //configs
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpVel = 20f;
    int health = 100;
    [SerializeField] float knockbackCount = 0;

    //state
    bool isAlive = true;
    bool facingLeft = false;
    bool canShoot = true;
    bool knockedFromRight;
    bool hasBow = false;
    bool hasDoorKey = false;
    bool hasChestKey = false;

    //caches
    [SerializeField] GameObject damageDisplay;
    CapsuleCollider2D myCollider;
    BoxCollider2D feet;
    Rigidbody2D myRigidBody;
    Animator animator;
    Transform gun;
    Weapon weapon;

    void Start()
    {
        myCollider = GetComponent<CapsuleCollider2D>();
        feet = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        weapon = FindObjectOfType<Weapon>();
        gun = gameObject.transform.GetChild(0);
    }
    
    void Update()
    {
        if(isAlive)
        {
            if (knockbackCount <= 0)
            {
                Move();
                FlipPlayer();
                Jump();
            }
            else
            {
                knockbackCount -= Time.deltaTime * 5;
            }        
        }
    }
    
    //Adds velocity on X-axis in direction Player chooses
    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(deltaX * speed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
        if(Mathf.Abs(myRigidBody.velocity.x) > 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }


    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && (feet.IsTouchingLayers(LayerMask.GetMask("Ground")) || feet.IsTouchingLayers(LayerMask.GetMask("Enemy"))))
        {
            Vector2 JumpVelocity = new Vector2(0f, jumpVel);
            myRigidBody.velocity += JumpVelocity;
        }
    }

    //flips the character to the direction it is moving
    private void FlipPlayer()
    {
        bool movingHorizontally = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        if (movingHorizontally)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
            if(myRigidBody.velocity.x < 0)
            {
                if (facingLeft) { return; }
                gun.transform.Rotate(0f, 180f, 0f);
                facingLeft = true;
            }
            else
            {
                if(!facingLeft) { return; }
                gun.transform.Rotate(0f, 180f, 0f);
                facingLeft = false;
            }
        }
    }

    public void ReceiveDamage(int amount, bool isMovingRight)
    {
        if (knockbackCount <= 0) { knockbackCount = 1f; }
        ApplyKnockback((float)amount, !isMovingRight);
        RemoveHealth(amount);
    }

    public void RemoveHealth(int amount)
    {
        health -= amount;
        SpawnDamageDisplay(amount);
        if(health <= 0)
        {
            isAlive = false;
            Death();
        }
    }

    private void ApplyKnockback(float knockback, bool knockedFromRight)
    {
        if (knockedFromRight)
        {
            myRigidBody.velocity = new Vector2(-knockback, knockback);
        }
        else if(!knockedFromRight)
        {
            myRigidBody.velocity = new Vector2(knockback, knockback);
        }
        //knockbackCount -= Time.deltaTime * 10;
    }

    public void ApplyKnockUp(float knockUp)
    {
        myRigidBody.velocity = new Vector2(0, knockUp);
    }

    private void Death()
    {
        //Found bug, Player "ice-skating" when dead. has to do with Rigidbody and ZeroFriction.
        SetCanShoot();
        animator.SetTrigger("Dead");
        gameObject.layer = 14;
    }

    public bool GetFacingLeft()
    {
        return facingLeft;
    }

    public void SetCanShoot()
    {
        canShoot = !canShoot;
    }
    public bool GetCanShoot()
    {
        return canShoot;
    }

    public void TriggerShooting()
    {
        if(!hasBow)
        {
            animator.SetTrigger("Throwing");
        }
        else
        {
            animator.SetTrigger("Shooting");
        }
    }

    public void CallShoot()
    {
        weapon.Shoot();
    }

    public bool GetIsAlive()
    {
        return isAlive;
    }

    public void PickupItem(string item)
    {
        Debug.Log("Picked up " + item);
        switch(item)
        {
            case "Bow(Clone)":
                SetHasBow();
                break;
            case "Door Key(Clone)":
                SetHasDoorKey(true);
                break;
            case "Chest Key(Clone)":
                SetHasChestKey(true);
                break;
            default:
                Debug.Log("PickupItem() was called with no/no known item.");
                break;
        }
    }

    public void SetHasBow()
    {
        hasBow = !hasBow;
        if(!hasBow)
        {
            weapon.SetWeapon(0);
        }
        else
        {
            weapon.SetWeapon(1);
        }
    }

    public bool GetHasBow()
    {
        return hasBow;
    }

    public void SetHasDoorKey(bool setter)
    {
        hasDoorKey = setter;
    }

    public bool GetHasDoorKey()
    {
        return hasDoorKey;
    }

    public void SetHasChestKey(bool setter)
    {
        hasChestKey = setter;
    }

    public bool GetHasChestKey()
    {
        return hasChestKey;
    }

    private void SpawnDamageDisplay(int amount)
    {
        damageDisplay.GetComponent<TextMeshPro>().text = amount.ToString();
        Instantiate(damageDisplay, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
}
