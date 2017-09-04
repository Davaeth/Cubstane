using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;
    public GameManager game;

    public GameObject jebut;

    void OnCollisionEnter (Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            Instantiate(jebut, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<GameManager>().EndGame();

        }
	}
}