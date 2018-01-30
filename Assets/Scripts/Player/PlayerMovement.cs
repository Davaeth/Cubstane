using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    private float forwardforce = 6000f; // force about moving forward (player can not to "stop")
    private float sidewaysForce = 50f; // force about moving left and right
    private float jumpForce = 75000f; // force about jumping

    public GameObject death;
    private bool jump = false;

    private float jumpRange = 0.7f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.AddForce(horizontal * sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Input.GetKeyDown(KeyCode.Space))
            jump = true;

        // Statements which allows to use "special events"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.LoadMenu();
        }

        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) 
                    && BadgeDeath.PowerEarned == true) //This line says that if you hold Sifht you will be able to "sprint";
        {
            forwardforce = 15000f;
            jumpForce = 90000;
            sidewaysForce = 100f;
        }
        else
        {
            forwardforce = 6000f;
            jumpForce = 75000;
        }
    }

    void FixedUpdate()
    {
        if (jump && IsGrounded())
        {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0);
            jump = false;
        }

        // Moving declarations
        rb.AddForce(0, 0, forwardforce * Time.deltaTime);

        //Statement about dying
        if (rb.position.y < -1f)
        {
            Instantiate(death, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<Level>().EndGame();
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(gameObject.transform.position, Vector3.down, jumpRange);
    }
}
