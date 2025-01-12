using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowDuration = 2f;
    public float slowCooldown = 5f;
    public bool slowActivated = false;

    public KeyCode slowTrigger = KeyCode.E;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(slowTrigger) && !slowActivated)
        {
            DoSlow();
        }

       Time.timeScale += (1f / slowDuration) * Time.unscaledDeltaTime;
       Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1);
        
    }

    public void DoSlow()
    {
        StartCoroutine(SlowCooldown());
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    IEnumerator SlowCooldown()
    {
        slowActivated = true;
        yield return new WaitForSeconds(slowCooldown + slowDuration);
        slowActivated = false;
    }
}
