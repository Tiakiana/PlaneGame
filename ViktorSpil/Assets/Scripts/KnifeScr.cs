using UnityEngine;
using System.Collections;

public class KnifeScr : MonoBehaviour {
    public GameObject knife;
    public GameObject stab; // Use this for initialization
    public GameObject drawBack;
    bool stabbing = false;
    public float stabspeed;
    void Start () {
      //  StartCoroutine("Stabby");
	}



    IEnumerator Stabby() {
        while (Vector2.Distance(knife.transform.position, stab.transform.position)> 0.1f)
        {
            transform.RotateAround(transform.position, Vector3.forward, stabspeed * Time.deltaTime);
            yield return null;
        }
        while (Vector2.Distance(knife.transform.position, drawBack.transform.position) > 0.1f)
        {
            transform.RotateAround(transform.position, Vector3.forward, (-stabspeed/2) * Time.deltaTime);
            yield return null;
        }
        stabbing = false;

    }

    public void StartStabbing() {
        if (stabbing == false)
        {
            stabbing = true;
            StartCoroutine("Stabby");
        }

    }

	// Update is called once per frame
	void Update () {
        
        
	}
}
