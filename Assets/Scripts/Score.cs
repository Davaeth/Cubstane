using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text score;

    public PlayerCollision stop;

	// Update is called once per frame
	void Update () {

        //if (stop.isgameOver == false) score.text = Time.fixedTime.ToString("0");

        //else Time.timeScale = 0;

	}
}
