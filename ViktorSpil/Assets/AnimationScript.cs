using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour
{
    private Animator anim;
	// Use this for initialization
	void Start ()
	{
	    anim = GetComponent<Animator>();
	}

    public void StartAnimBoom()
    {
        anim.SetTrigger("Start");
    }

    // Update is called once per frame
	void Update () {
	    if (Input.GetKeyUp("g"))
	    {
	        StartAnimBoom();
	    }
	}
}
