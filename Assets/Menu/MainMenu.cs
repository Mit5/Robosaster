using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject levelSelect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelSelect()
    {
        Menu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void BackToMain()
    {
        Menu.SetActive(true);
        levelSelect.SetActive(false);
    }

}
