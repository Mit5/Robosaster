using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Reload()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
