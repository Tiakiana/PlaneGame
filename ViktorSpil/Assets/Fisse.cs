using UnityEngine;
using System.Collections;

public class Fisse : MonoBehaviour
{
    public GameObject go;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyUp("h"))
	    {
	        go.GetComponent<XWingMovement>().BroadcastMessage("Straight", 3);
	    }
	}
}
