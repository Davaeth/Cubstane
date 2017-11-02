using UnityEngine;

public class BadgeDeath : MonoBehaviour {

    // Why is it in separate script?
    // Because when i did it in scripts PLayerMovement and TimeBody and tried to place 2 same badges then it was bugging.
    // One badge was destroying, but second no. So it's why this script even exists.

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
