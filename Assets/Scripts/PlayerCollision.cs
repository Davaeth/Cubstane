using UnityEngine;
using UnityEngine.Animations;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;
    public Level game;

    public GameObject death;

    void OnCollisionEnter (Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            Instantiate(death, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<Level>().EndGame();
        }
	}
}