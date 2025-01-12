using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform PosRShot;
    public Transform PosLShot;
    public Transform PosR;
    public Transform PosL;
    public GameObject player;
    private SpriteRenderer sprite;
    [Header("Input")]
    public KeyCode shootInput = KeyCode.Mouse0;

    public float offset;
    Transform shotOrigin;
    public GameObject projectile;

    private int faceMultiplier = 1;

    private PlayerController movement;
    public float cooldown;
    public bool firing = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movement = player.GetComponent<PlayerController>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Sprite Flip
        if (movement.facingRight)
        {
            sprite.flipX = true;
            transform.position = PosL.position;
            faceMultiplier = -1;
            shotOrigin = PosLShot;
        }
        else if (!movement.facingRight)
        {
            sprite.flipX = false;
            transform.position = PosR.position;
            faceMultiplier = 1;
            shotOrigin = PosRShot;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        
        if(Input.GetKeyDown(shootInput))
        {
            if(firing)
            {
                Instantiate(projectile, shotOrigin.transform.position, transform.rotation);
                StartCoroutine(RateOfFire());
            }

        }

    }

    IEnumerator RateOfFire()
    {
        firing = false;
        yield return new WaitForSeconds(cooldown);
        firing = true;
    }
}
