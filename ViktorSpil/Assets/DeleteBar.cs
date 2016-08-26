using UnityEngine;
using System.Collections;

public class DeleteBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown("b"))
	    {
	        gameObject.SetActive(false);
	    }
	}
}
