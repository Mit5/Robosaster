using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{

    public bool inRange = false;
    public float checkRadius;
    public Transform shotOrigin1;
    public Transform shotOrigin2;
    private float TimebtwShots;
    public float StartTimebtwShots;
    public GameObject projectile;
    public GameObject Player;
    public LayerMask player;

    void Start()
    {
        TimebtwShots = 4f;
        Player = GameObject.FindGameObjectWithTag("Player");
        TimebtwShots = StartTimebtwShots;
    }

    void Update()
    {

        Vector3 differnce = Player.transform.position  - transform.position;
        float rotZ = Mathf.Atan2(differnce.y, differnce.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        TimebtwShots -= Time.deltaTime;
        inRange = Physics2D.OverlapCircle(transform.position, checkRadius, player);
        if(inRange)
        {
            if (TimebtwShots <= 0)
            {
                Instantiate(projectile, shotOrigin1.position, Quaternion.identity);
                Instantiate(projectile, shotOrigin2.position, Quaternion.identity);
                TimebtwShots = StartTimebtwShots;
            }
        }
    }
}