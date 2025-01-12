using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispayFail : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject Fail;

    public int killedEnemies = 0;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Fail.SetActive(false);
        Time.timeScale = 1f;
        killedEnemies = 0;
    }

    private void FixedUpdate()
    {
        if (Player.GetComponent<PlayerController>().health == 0 || killedEnemies == 2)
        {
            Fail.SetActive(true);
        }
        else if (Player.GetComponent<PlayerController>().health > 0 && killedEnemies == 0)
        {
            Fail.SetActive(false);
        }
    }
}
