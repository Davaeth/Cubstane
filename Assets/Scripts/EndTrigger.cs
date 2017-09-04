using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameManager end;

    void OnTriggerEnter()
    {
        end.CompleteLevel();
    }
}
