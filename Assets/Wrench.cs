using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : MonoBehaviour
{
    public Transform PosR;
    public Transform PosL;
    private PlayerController movement;
    public GameObject player;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movement = player.GetComponent<PlayerController>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Sprite Flip
        if (movement.facingRight)
        {
            sprite.flipX = true;
            transform.position = PosL.position;
        }
        else if (!movement.facingRight)
        {
            sprite.flipX = false;
            transform.position = PosR.position;
        }
    }
}
