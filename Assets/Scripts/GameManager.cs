﻿using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{

    public static void LoadLevel(int? levelIndex = null)
    {
        SceneManager.LoadScene(levelIndex ?? SceneManager.GetActiveScene().buildIndex + 1);
        hp = 3;
        Debug.Log(hp);
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
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
    public static void GameOptions()
    {
        SceneManager.LoadScene((int)MenuItem.Options);
    }
    public static void LoadMenu()
    {
        SceneManager.LoadScene((int)MenuItem.Menu);
    }
}

public enum MenuItem : int
{
    Menu = 0,
    Options = 1,
    StartGame = 2
}
