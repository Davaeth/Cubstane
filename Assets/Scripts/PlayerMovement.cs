using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float forwardforce = 6000f; // force about moving forward (player can not to "stop")
    public float sidewaysForce = 20f; // force about moving left and right
    public float jumpForce = 75000; // force about jumping

    public bool isOnGround = true;
    public bool powerEarned = false;
    public GameObject jebut;

    void FixedUpdate() {

        // Moving declarations
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

        //Statement about dying
        if(rb.position.y < -1f)
        {
            Instantiate(jebut, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<GameManager>().EndGame();
        }

        // Statements which allows to use "special events"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ) && powerEarned == true ) //This line says that if you hold Sifht you will be able to "sprint";
        {
            forwardforce = 15000f;
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

        if (collisionInfo.collider.tag == "Sprint") //PLayer will be able to "sprint" when he obtained a yellow cube
        {
            powerEarned = true;
        }
    }
}
