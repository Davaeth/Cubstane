using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public GameObject completelevelUI;
    public GameObject gameOverUI;

    public bool isGameOver = false;

    public void CompleteLevel()
    {
        completelevelUI.SetActive(true);
    }

    public void EndGame()
    {

        if (isGameOver == false)
        {
            GameManager.PlayerDeath(); // Decreasing player hp whenever player "dies".

            if (GameManager.GetHp() <= 0) // When player hp reach 0 or above gameOverUI is setting to enable and change scene to Menu.
            {
                gameOverUI.SetActive(true);
                Invoke("LoadMenu", 1.2f);
            }else // This lines is ordered to "kill" the player.
            {
                isGameOver = true;
                Invoke("Restart", 1f);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void LoadMenu()
    {
        GameManager.LoadMenu();
    }
}
