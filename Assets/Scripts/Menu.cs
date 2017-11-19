using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour { 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            GameManager.StartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.QuitGame();
        }
    }

    public void StartGame()
    {
        GameManager.StartGame();
    }
    public void Quit()
    {
        GameManager.QuitGame();
    }

    public void Options()
    {
        GameManager.GameOptions();
    }

    public void LevelSelector()
    {
        GameManager.SelectLevel();
    }
}
