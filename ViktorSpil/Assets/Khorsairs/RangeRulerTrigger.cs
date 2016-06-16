using UnityEngine;
using System.Collections;

public class RangeRulerTrigger : MonoBehaviour
{
    public int Distance;
    private Transform daddy;
    public GameObject Marker;

    // Use this for initialization
    void Start ()
	{
	    daddy = transform.parent.transform;
	}

    void OnTriggerStay2D(Collider2D col)
    {
     //   Debug.Log("His Here!" + col.name);
     /*
        Vector2 direction = col.transform.position - daddy.position;
        float angle = Vector2.Angle(direction, daddy.up);
        Debug.Log(""+ angle);
        if (angle < 45)
        {
            Debug.Log("I Can Fire On Him Sir!");
        }
        else
        {
            Debug.Log("Within range but out of arc");
            Debug.Log("");
        }

    */

    }


    void TestRangeNear()
    {
        Collider2D [] colls = Physics2D.OverlapCircleAll(transform.position, 7.5f);

        foreach (Collider2D item in colls)
        {
            if ( !item.gameObject.Equals(daddy.gameObject) && item.gameObject.tag != "Aim")
            {
                Vector2 direction = item.transform.position - daddy.position;
                float angle = Vector2.Angle(direction, daddy.up);
                float dist = Distance*2.5f;
                //Debug.Log("" + angle);
                if (angle < 45 && Vector2.Distance(daddy.transform.position,item.transform.position)<=dist && Vector2.Distance(daddy.transform.position,item.transform.position)>dist-2.5f)
                {
                    Debug.Log("I Can Fire On Him Sir! He is at range " + Distance);
                    if (Marker!= null)
                    {
                        Marker.gameObject.SetActive(true);
                        Marker.gameObject.transform.position = item.transform.position;
                        Marker.GetComponent<MarkerFade>().Starter();
                    }

                }
                else
                {
                    Marker.gameObject.SetActive(false);

                   // Debug.Log("Within range but out of arc");
                   // Debug.Log("");
                }
                //Debug.Log(item.gameObject.name);

            }


        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
