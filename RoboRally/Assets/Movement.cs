using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void DriveForward()
    {
        transform.position += transform.right;
    }
    void DriveBackward()
    {
        transform.position -= transform.right;
    }

    void TurnLeft()
    {

        transform.RotateAround(transform.position,Vector3.forward,90);
    }

    void TurnRight()
    {
        transform.RotateAround(transform.position, Vector3.forward, -90);

    }

    // Update is called once per frame
    void Update () {
	    if (Input.GetKeyUp("w"))
	    {
	        DriveForward();
	    }
        if (Input.GetKeyUp("s"))
        {
            DriveBackward();
        }
        if (Input.GetKeyUp("a"))
        {
            TurnLeft();
        }
        if (Input.GetKeyUp("d"))
        {
            TurnRight();
        }

    }
}
