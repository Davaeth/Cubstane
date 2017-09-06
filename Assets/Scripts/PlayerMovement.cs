using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float forwardforce = 6000f;
    public float sidewaysForce = 20f;
    public float jumpForce = 75000;

    public bool isOnGround = true;
    public bool powerEarned = false;
    public GameObject jebut;

    void FixedUpdate() {

        rb.AddForce(0, 0, forwardforce * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0);
            isOnGround = false;
        }

        if(rb.position.y < -1f)
        {
            Instantiate(jebut, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<GameManager>().EndGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ) && powerEarned == true ) //This line says that if you hold Sifht you will be able to "sprint";
        {
            forwardforce = 20000f;
            jumpForce = 90000;
        }
        else {
            forwardforce = 6000f;
            jumpForce = 75000;
        }
    }


    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
        {
            isOnGround = true;
        }

        if (collisionInfo.collider.tag == "Sprint") //But you will be able to use this power only after obtained a special yellow badge;
        {
            Destroy(GameObject.FindGameObjectWithTag("Sprint"));
            powerEarned = true;
        }
    }
}
