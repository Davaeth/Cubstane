using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {

    public bool isRewinding = false;

    public float recordTime = 0.8f;

    List<PointInTime> pointsInTime;

    Rigidbody rb;

	void Start () {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
	}
	
    //If you put down your LeftCTRL button you will start rewind time. Else if you put it up the rewind will be stopped.
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            StartRewind();
        if (Input.GetKeyUp(KeyCode.LeftControl))
            StopRewind();
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
    }

}
