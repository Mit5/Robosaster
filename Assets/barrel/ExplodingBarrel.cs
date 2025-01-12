using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour
{
    public LayerMask player;
    public bool inRange = false;
    public float checkRadius;
    public float health;
    public GameObject Player;
    public GameObject ParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        inRange = Physics2D.OverlapCircle(transform.position, checkRadius, player);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet") || other.CompareTag("PlayerBullet"))
        {
            Damage();
            if(health <= 0)
            {
                Instantiate(ParticleSystem, transform.position, Quaternion.identity);
                Destroy(gameObject);
                if (inRange)
                {
                    Player.GetComponent<PlayerController>().BarrelDamage();
                    
                }
            }
        }
    }

    void Damage()
    {
        health -= 1;
    }
    
}
