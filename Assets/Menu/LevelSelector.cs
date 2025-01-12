using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void Select(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }


}
