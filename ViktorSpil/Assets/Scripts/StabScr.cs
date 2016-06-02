using UnityEngine;
using System.Collections;

public class StabScr : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Øfferen");
          //  DestroyObject(other.gameObject);
            
        }

    }

        // Update is called once per frame
        void Update () {
        
	}
}
