using UnityEngine;
using System.Collections;

public class FireSpear : MonoBehaviour {
    bool thrown = false;
    public string FireButton = "e";
    public float force = 50;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(FireButton) && thrown == false)
        {
            ThrowSpear();

        }
	}

    void ThrowSpear() {
        if (transform.parent!=null)
        {
            transform.parent = null;
            gameObject.AddComponent<Rigidbody2D>().AddForce(Vector2.right * force * transform.localScale.x, ForceMode2D.Impulse);
        }
    }
}
