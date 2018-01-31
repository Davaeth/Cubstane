using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour {

    public Dropdown quality;
    public Slider volume;

    public AudioMixer mixer;

    private float volumeValue;

    void Start()
    {
        quality.value = QualitySettings.GetQualityLevel();

        mixer.GetFloat("Volume", out volumeValue);
        volume.value = volumeValue;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            Return();
        }
    }

    public void Return()
    {
        GameManager.LoadMenu();
    }

    public void SetVolume(float _volume)
    {
        mixer.SetFloat("Volume", _volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        quality.RefreshShownValue();
    }
}
