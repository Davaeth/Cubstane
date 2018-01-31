using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        hp = 3;
        Cursor.visible = false;
    }
    public static void LoadLevel(int? levelIndex = null)
    {
        SceneManager.LoadScene(levelIndex ?? SceneManager.GetActiveScene().buildIndex + 1);
        hp = 3;
        Cursor.visible = false;
    }
    private static int hp = 3;

    public static int GetHp() { return hp; }

    public static void PlayerDeath()
    {
        hp = hp - 1;
    }

    public static void StartGame()
    {
        LoadLevel((int)MenuItem.StartGame);
        Cursor.visible = false;
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
    public static void GameOptions()
    {
        SceneManager.LoadScene((int)MenuItem.Options);
    }

    public static void SelectLevel()
    {
        SceneManager.LoadScene((int)MenuItem.SelectLevel);
    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene((int)MenuItem.Menu);
        Cursor.visible = true;
    }

    public static void LoadShip()
    {
        SceneManager.LoadScene((int)MenuItem.ShipReview);
        Cursor.visible = false;
    }
}

public enum MenuItem : int
{
    Menu = 0,
    Options = 1,
    SelectLevel = 2,
    ShipReview = 3,
    StartGame = 4

}
