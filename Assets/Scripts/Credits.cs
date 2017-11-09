using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Quit ()
    {
        Application.Quit();
    }

    public void Restart ()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
