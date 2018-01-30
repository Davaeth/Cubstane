using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour {


    public Dropdown quality;

    public AudioMixer audioMixer;

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

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
