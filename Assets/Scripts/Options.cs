using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("Menu");
        }
    }

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

    public void Return()
    {
        SceneManager.LoadScene("Menu");
    }

}
