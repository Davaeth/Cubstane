using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text score;

    public PlayerCollision stop;
    public float HighScore;
    public float LastScore;
    public float FirstStep;

    GameObject Player;

    void Start(){
        
        FirstStep = Player.transform.position.x;

    }

    // Update is called once per frame
    void Update () {

        Player = GameObject.FindGameObjectWithTag("Player");

        if (stop.isGameOver == false)
        {          
            LastScore = Player.transform.position.x;
            HighScore = LastScore = FirstStep;
        }

        score.text = HighScore.ToString();
    }
}
