using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Camera : MonoBehaviour {

    float yaw;
    float pitch;
    float rotationSpeed = 300f;
    float moveSpeed = 150f;

	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float jump = Input.GetAxis("Camera_Move_Y") * moveSpeed * Time.deltaTime;

        transform.Translate(horizontal, jump, vertical);

        pitch += rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse Y");
        yaw += rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse X");

        // Clamp pitch:
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        // Wrap yaw:
        while (yaw < 0f)
        {
            yaw += 360f;
        }
        while (yaw >= 360f)
        {
            yaw -= 360f;
        }
        transform.eulerAngles = new Vector3(-pitch, yaw, 0f);
    }
}
