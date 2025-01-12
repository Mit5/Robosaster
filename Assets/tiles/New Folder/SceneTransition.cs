using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public LayerMask Player;
    public bool inRange = false;
    public float checkRadius;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inRange = Physics2D.OverlapCircle(transform.position, checkRadius, Player);
        if (inRange)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
