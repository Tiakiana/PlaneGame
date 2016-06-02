using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    GameObject player;
    public float sight;
    public float range;
    public float speed;
    public GameObject pivotpoint;
    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("StartAI");
	}
 public   bool going = false;
    float calcDistance() {
        return Vector2.Distance(gameObject.transform.position, player.transform.position);

    }

    IEnumerator StartAI()
    {
        

        while (true)
        {

            
            if (Vector2.Distance(gameObject.transform.position, player.transform.position) < sight && !going && Vector2.Distance(gameObject.transform.position, player.transform.position)>range)
            {
                StartCoroutine("Hunt");
                Debug.Log("Hunt started");

                going = true;
            }


            if (calcDistance()<= range)
            {
                pivotpoint.SendMessage("StartStabbing");
            //    gameObject.GetComponent<AudioSource>().Stop();


            }


            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Hunt() {
        gameObject.GetComponent<AudioSource>().Play();
        GameObject.Find("Main Camera").GetComponent<cameraShake>().Shake();
        while (Vector2.Distance(gameObject.transform.position, player.transform.position)> range && Vector2.Distance(gameObject.transform.position, player.transform.position) < sight)
        {

            if (player.transform.position.x < transform.position.x)
            {
                transform.position +=  -transform.right * speed * 0.01f;
                yield return null;
                // Debug.Log("Going");
                transform.localScale = new Vector3(1, 1, 1);

            }
            else
            {
                transform.position += transform.right * speed * 0.01f;
                yield return null;
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        //  StopCoroutine("Hunt");
        going = false;
        Debug.Log("stopping now");
    }

	// Update is called once per frame
	void Update () {
	
	}
}
