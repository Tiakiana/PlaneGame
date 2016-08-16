using UnityEngine;
using System.Collections;

public class Rotations : MonoBehaviour
{
    public float starter;
    public float degrees;
    public float rotation;

	// Use this for initialization
	void Start ()
	{
	}

    public void SetDegrees(int deg, int rot)
    {
        degrees = deg;
        rotation = rot;
    }

    // Update is called once per frame
	void Update () {
	    if (starter< degrees)
	    {
            transform.RotateAround(transform.position, Vector3.forward, rotation);
            starter += 1;

        }



    }
}
