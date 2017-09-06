using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {

    public bool isRewinding = false;
    public bool powerEarned = false;

    public float recordTime = 0.8f;

    List<PointInTime> pointsInTime;

    Rigidbody rb;

	void Start () {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
	}
	
    //If you put down your LeftCTRL button you will start rewind time. Else if you put it up the rewind will be stopped.
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftControl) && powerEarned == true)
            StartRewind();
        if (Input.GetKeyUp(KeyCode.LeftControl) && powerEarned == true)
            StopRewind();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Badge") //But you will be able to use this power only after obtained a special blue badge;
        {
            Destroy(GameObject.FindGameObjectWithTag("Badge"));
            powerEarned = true;
        }
    }

    public void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        } else
        {
            StopRewind();
        }
    }

    void Record ()
    {
        if(pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime)) //Rewind continues over 0.8 sec.
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }

        pointsInTime.Insert(0, new PointInTime(transform.position,transform.rotation));
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
        powerEarned = false; //Thanks to this bool player can use the RewindTime power only once;
    }

}
