﻿using UnityEngine;
using System.Collections;

public class DiceBox : MonoBehaviour {
    public bool player1 = false;


    [HideInInspector]
    public bool facingRight = true;         // For determining which way the player is currently facing.
    [HideInInspector]
    public bool jump = false;               // Condition for whether the player should jump.


    public float moveForce = 365f;          // Amount of force added to move the player left and right.
    public float maxSpeed = 5f;             // The fastest the player can travel in the x axis.
    public AudioClip[] jumpClips;           // Array of clips for when the player jumps.
    public float jumpForce = 1000f;         // Amount of force added when the player jumps.
    public AudioClip[] taunts;              // Array of clips for when the player taunts.
    public float tauntProbability = 50f;    // Chance of a taunt happening.
    public float tauntDelay = 1f;           // Delay for when the taunt should happen.


    private int tauntIndex;                 // The index of the taunts array indicating the most recent taunt.
    private Transform groundCheck;          // A position marking where to check if the player is grounded.
    private bool grounded = true;          // Whether or not the player is grounded.
    private Animator anim;                  // Reference to the player's animator component.



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("r"))
        {
            GetComponent<Rigidbody2D>().AddTorque(40f);
        }
        if (Input.GetKeyDown("h"))
        {
            jump = true;
        }

        if (Input.GetKeyDown("q"))
        {
            GetReading();

        }
	}
    /*
    int x = 30;
if (Enumerable.Range(1,100).Contains(x))
    //true

if (x >= 1 && x <= 100)
    */
    void GetReading() {
        Debug.Log("" + transform.rotation.z);
        if (transform.rotation.z >= -10 && transform.rotation.z <=10 )
        {
            Debug.Log("Diamond");
        }
        if (transform.rotation.z >= 260 && transform.rotation.z <= 280)
        {
            Debug.Log("triangle");
        }
        if (transform.rotation.z >= 170 && transform.rotation.z <= 190)
        {
            Debug.Log("Arrow");
        }
        if (transform.rotation.z >= 80 && transform.rotation.z <= 100)
        {
            Debug.Log("Star");
        }

    }
    void FixedUpdate() {

        float h = Input.GetAxis("Horizontal");

        // The Speed animator parameter is set to the absolute value of the horizontal input.
        // anim.SetFloat("Speed", Mathf.Abs(h));

        // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            // ... add a force to the player.
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        // If the input is moving the player right and the player is facing left...
       // if (h > 0 && !facingRight)
            // ... flip the player.
           // Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
       // else if (h < 0 && facingRight)
            // ... flip the player.
           // Flip();

        // If the player should jump...
        if (jump)
        {
            // Set the Jump animator trigger parameter.
            //anim.SetTrigger("Jump");

            // Play a random jump audio clip.
            //int i = Random.Range(0, jumpClips.Length);
            //AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

            // Add a vertical force to the player.
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            jump = false;
        }

        
    
    }
}