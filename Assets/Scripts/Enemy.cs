using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    //Configs
    [SerializeField] float movementSpeed = 2f;
    [SerializeField] GameObject[] items; 
    [SerializeField] int dmg = 10;
    [SerializeField] int health = 100;
    float healthBarDiff;
	//Caches
	Health playerHealth;
    Animator animator;
    Rigidbody2D myRigidbody;
    [SerializeField] GameObject bar;
    [SerializeField] GameObject damageDisplay;
    Transform hpBar;
    Player player;
    //Waypoints
    [SerializeField] Transform[] waypoints;
    int waypointIndex = 0;
    //State
    bool isMovingRight = true;
    bool isAttacking = false;
    bool isDead = false;
    bool droppedItem = false;

    void Start()
    {
		playerHealth = FindObjectOfType<Health>();
        hpBar = transform.Find("HealthBar");
        player = FindObjectOfType<Player>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthBarDiff = 1f / (float)health;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            if(waypoints.Length > 0 && !isAttacking)
            {
                foreach(Transform waypoint in waypoints)
                {
                    Move();
                }
            }
            else if(!isAttacking)
            {
                if (isMovingRight) { transform.position = new Vector2(transform.position.x + (movementSpeed * Time.deltaTime), transform.position.y); }
                else { transform.position = new Vector2(transform.position.x - (movementSpeed * Time.deltaTime), transform.position.y); }
            }
        }
        else
        {
            StartCoroutine(Death());
        }
    }

    private void Move()
    {       
        animator.SetBool("Idle", false);
		if(gameObject.name == "Golem")
		{
			animator.SetBool("IsAttacking", false);
		}
        transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, waypoints[waypointIndex].position.x, movementSpeed * Time.deltaTime), transform.position.y);
        if(transform.position.x < waypoints[waypointIndex].transform.position.x) { isMovingRight = true; }
        else { isMovingRight = false; }
        if (transform.position.x == waypoints[waypointIndex].position.x)
        {
            Flip();
            waypointIndex++;
            
            if (waypointIndex == waypoints.Length)
            
            waypointIndex = 0;
        }        
    }
        //Flips the object on the X-Axis
    private void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, 1f);
        hpBar.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Foreground")
        {
            Flip();
            isMovingRight = !isMovingRight;
        }
        else if(collision.gameObject.tag == "Player" && !isAttacking && player.GetIsAlive())
        {
            PlayAttack();
        }
    }

    private void PlayAttack()
    {
        animator.SetTrigger("Attacking");
    }

    public void SetIsAttacking()
    {
        isAttacking = !isAttacking;
		if(gameObject.name == "Golem")
		{
			animator.SetBool("IsAttacking", true);
		}
    }

    public void DealDamage()
    {
        player.ReceiveDamage(dmg, isMovingRight);
    }

    public void ReceiveDamage(int amount)
    {        
        health -= amount;
        SpawnDamageDisplay(amount);
		if(gameObject.name == "Golem") { animator.SetTrigger("Hurt"); }		
		myRigidbody.velocity = new Vector2(0f, 0f);
        bar.GetComponent<Transform>().localScale = new Vector3(health * healthBarDiff, 1f, 1f);
        if(health <= 0)
        {
            bar.GetComponent<Transform>().localScale = new Vector3(0f, 1f, 1f);
            isDead = true;
        }
    }

    private IEnumerator Death()
    {
        animator.SetTrigger("Death");
        if(items.Length > 0 && !droppedItem)
        {
            foreach(GameObject item in items)
			{
				if(item.name == "Heart")
				{
					if(playerHealth.IsHurt() && ((int)Random.Range(2f, 6f) % 2 == 0))
					{
						SpitOutItem(item); 
					}
					else
					{
						break;
					}
				}
				else// if(item.name != "Heart")
				{
					Debug.Log(item.name);
					SpitOutItem(item);
				}
				droppedItem = true;
			}
        }
        gameObject.layer = 14;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void SpitOutItem(GameObject item)
    {
        Instantiate(item, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);        
    }

    private void SpawnDamageDisplay(int amount)
    {
        damageDisplay.GetComponent<TextMeshPro>().text = amount.ToString();
        Instantiate(damageDisplay, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }

	public bool GetIsDead()
	{
		return isDead;
	}
}
