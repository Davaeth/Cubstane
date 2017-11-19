using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelCreator : MonoBehaviour { 

    public Text LevelName;
    public Button LeftArrow;
    public Button RightArrow;

    public LevelCreator()
    {
         _levels = new List<string> { "Level01", "Level02", "Level03", "Level04" };
    }

    void Awake()
    {
        SetArrowVisible();
        SetLevelName();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            Return();
        }
    }

    public void StartGame()
    {
        GameManager.LoadLevel(_levels[_levelSelected]);
    }

    public void Return()
    {
        GameManager.LoadMenu();
    }

    private void SetLevelName()
    {
        if (_levelSelected < _levels.Count)
        {
            LevelName.text = _levels[_levelSelected].ToUpper();
        }
    }
    public void NextLevel()
    {
        _levelSelected += 1;
        if(_levelSelected >= _levels.Count)
        {
            _levelSelected = _levels.Count;

        }
        SetArrowVisible();
        SetLevelName();
    }
    public void PrevLevel()
    {
        _levelSelected -= 1;
        if(_levelSelected < 0)
        {
            _levelSelected = 0;
        }
        SetArrowVisible();
        SetLevelName();
    }

    private void SetArrowVisible()
    {
        if (_levelSelected == 0)
        {
            LeftArrow.gameObject.SetActive(false);
        }
        else if (_levelSelected + 1 == _levels.Count)
        {
            RightArrow.gameObject.SetActive(false);
        }
        else
        {
            LeftArrow.gameObject.SetActive(true);
            RightArrow.gameObject.SetActive(true);
        }
    }
    private int _levelSelected = 0;
    private List<string> _levels;
}
