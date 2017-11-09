using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            Return();
        }
    }

#region Graphics settings
    public void Low()
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void Medium()
    {
        QualitySettings.SetQualityLevel(1);
    }

    public void Ultra()
    {
        QualitySettings.SetQualityLevel(2);
    }
#endregion

    public void Return()
    {
        GameManager.LoadMenu();
    }
}
