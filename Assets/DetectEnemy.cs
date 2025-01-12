using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    public float checkRadius;
    public LayerMask enemy;
    bool inRange;
    public GameObject Wrench;
    public GameObject Gun;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inRange = Physics2D.OverlapCircle(transform.position,checkRadius,enemy);
        if(inRange)
        {
            Gun.SetActive(false);
            Wrench.SetActive(true);
            Gun.GetComponent<Gun>().firing = true;
        }
        else 
        {
            Gun.SetActive(true);
            Wrench.SetActive(false);
        }
    }
}
