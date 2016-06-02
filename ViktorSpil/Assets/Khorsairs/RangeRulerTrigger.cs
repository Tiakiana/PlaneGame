using UnityEngine;
using System.Collections;

public class RangeRulerTrigger : MonoBehaviour
{
    public int Distance;
    private Transform daddy;
	// Use this for initialization
	void Start ()
	{
	    daddy = transform.parent.transform;
	}

    void OnTriggerStay2D(Collider2D col)
    {
     //   Debug.Log("His Here!" + col.name);

        Vector2 direction = col.transform.position - daddy.position;
        float angle = Vector2.Angle(direction, daddy.up);
        Debug.Log(""+ angle);
        if (angle<45)
        {
            Debug.Log("I Can Fire On Him Sir!");
        }

    }

    // Update is called once per frame
	void Update () {
	
	}
}
