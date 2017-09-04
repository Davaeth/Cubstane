using UnityEngine;

public class Credits : MonoBehaviour {

    public void Quit ()
    {
        Application.Quit();
    }

    public void Restart ()
    {
        Application.LoadLevel(0);
    }
    
}
