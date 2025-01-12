using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public bool isRepaired;
    public GameObject Friendly;
    public KeyCode repairKey = KeyCode.Mouse0;

    public bool inRepairRange = false;

    public float repairTime;

    float repairProgress = 0;

    public float checkRadius;
    public LayerMask player;

    // Update is called once per frame
    void Update()
    {
        inRepairRange = Physics2D.OverlapCircle(transform.position, checkRadius, player);

        if(inRepairRange)
        {
            if(Input.GetKey(repairKey))
            {
                repairProgress += Time.deltaTime;
            }
            if(repairProgress >= repairTime)
            {
                isRepaired = true;
            }
        }

        if (isRepaired)
        {
            Instantiate(Friendly, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
