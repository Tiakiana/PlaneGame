using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    private Vector3 defaultpos;
	// Use this for initialization
	void Start ()
	{
	    defaultpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyUp("w"))
	    {
	        transform.position+=Vector3.up;
	    }
        if (Input.GetKeyUp("s"))
        {
            transform.position -= Vector3.up;
        }
        if (Input.GetKeyUp("a"))
        {
            transform.position += Vector3.left;
        }
        if (Input.GetKeyUp("d"))
        {
            transform.position += Vector3.right;
        }
        if (Input.GetKeyUp("e"))
        {
            transform.position = defaultpos;
        }
    }
}
