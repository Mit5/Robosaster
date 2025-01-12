using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float lifeTime;
    private PlayerController movement;
    public GameObject player;
    private SpriteRenderer sprite;
    private float FaceMulti = 1;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        movement = player.GetComponent<PlayerController>();
        if(movement.facingRight)
        {
            sprite.flipX = false;
            FaceMulti = -1;
        }
        else
        {
            sprite.flipX = true;
            FaceMulti = 1;
        }
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * FaceMulti  * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("turn"))
        {

        }
        else
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
