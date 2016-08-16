using UnityEngine;
using System.Collections;

public class ImClicked : MonoBehaviour
{

    public float TurnDegrees;

    public GameObject Daddy;

	// Use this for initialization
	void Start ()
	{
	    Daddy = transform.parent.transform.parent.gameObject;
	}

    private void OnMouseDown()
    {
        DoMe();
    }

    public void DoMe()
    {
     
    }

    // Update is called once per frame
	void Update () {
	
	}
}
