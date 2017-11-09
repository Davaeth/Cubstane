using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.QuitGame();
        }
    }

    public void Quit()
    {
        GameManager.QuitGame();
    }

    public void Restart ()
    {
        GameManager.LoadMenu();
    }
    
}
