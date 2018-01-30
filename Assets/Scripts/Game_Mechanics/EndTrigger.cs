using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour {

    public Level end;

    void OnTriggerEnter()
    {
        end.CompleteLevel();
        Invoke("LoadNextLevel", 1.7f);
    }

    void LoadNextLevel()
    {
        GameManager.LoadLevel();
    }
}
