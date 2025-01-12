using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject Health1;
    public GameObject Health2;
    public GameObject Gun;
    public GameObject SlowMo;
    public PlayerController pc;
    public Gun gun;
    public TimeManager timeManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pc.health == 1)
        {
            Health1.SetActive(false);
        }
        if(pc.health == 2)
        {
            Health1.SetActive(true);
        }
        if(pc.health <= 0)
        {
            Health2.SetActive(false);
            Health1.SetActive(false);
        }

        if(!gun.firing)
        {
            Gun.SetActive(false);
        }
        else
        {
            Gun.SetActive(true);
        }

        if (!timeManager.slowActivated)
        {
            SlowMo.SetActive(true);
        }
        else
        {
            SlowMo.SetActive(false);
        }
    }
}
