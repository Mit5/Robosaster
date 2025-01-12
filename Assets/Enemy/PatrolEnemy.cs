using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{

    public FailedScreen failedScreen;

    public float health = 2;

    public GameObject Destroyed;

    public float speed;

    private bool movingRight;
    public bool stunned = false;
    public float stunDuration = 2;
    public bool inRange = false;

    public float checkRadius;

    private float TimebtwShots;
    public float StartTimebtwShots;
    public GameObject projectile;

    public LayerMask player;

    void Start()
    {
        TimebtwShots = StartTimebtwShots;
    }

    void Update()
    {

        if (health <= 0)
        {
            Instantiate(Destroyed, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        TimebtwShots -= Time.deltaTime;
        inRange = Physics2D.OverlapCircle(transform.position, checkRadius, player);
        if(!stunned)
        {
            if (!inRange)
            {
                if (movingRight)
                {
                    transform.Translate(2 * Time.deltaTime * speed, 0, 0);

                }
                else
                {
                    transform.Translate(-2 * Time.deltaTime * speed, 0, 0);

                }
            }
            else
            {
                if (TimebtwShots <= 0)
                {
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    TimebtwShots = StartTimebtwShots;
                }
            }
        }
        else
        {
            TimebtwShots = StartTimebtwShots;
            transform.Translate(0,0,0);
        }
        
    }

    void OnTriggerEnter2D(Collider2D trig)
    {

        if (trig.CompareTag("PlayerBullet"))
        {
            if(health == 2)
            {
                stunned = true;
                StartCoroutine(RemoveStun());
            }
            health -= 1f;
        }

        if (trig.gameObject.CompareTag("turn"))
        {
            if (movingRight)
            {
                movingRight = false;
            }
            else
            {
                movingRight = true;
            }
        }
    }

    IEnumerator RemoveStun()
    {
        yield return new WaitForSeconds(stunDuration);
        stunned = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}