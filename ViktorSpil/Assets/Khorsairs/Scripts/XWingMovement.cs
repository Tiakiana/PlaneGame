using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
public enum Maneuvers
{
    Straight = 1, Bank, Turn
}
public class XWingMovement : MonoBehaviour
{
    private Vector3 start;
    private Vector3 target;
    public GameObject thing;
    public GameObject FlightManager;
    public Vector3 LastPosition;
    public Vector3 LastRotation;


    void Start () {
	thing = new GameObject();
        FlightManager = GameObject.FindGameObjectWithTag("FlightManager");
        Physics2D.IgnoreLayerCollision(13,13,true);
      
	}

    public void RotateMe(float angle)
    {
        transform.RotateAround(transform.position,transform.up,angle);
    }

    public void Straight(float speed)
    {
        start = transform.position;
       target = transform.position + transform.up * speed;
        StartCoroutine("GoingStraight");

    }
   /* public void Straight()
    {
        start = transform.position;
        target = transform.position + transform.up * 1;
        StartCoroutine("GoingStraight");

    }*/

    public void StraightKoiogran(float speed)
    {
        start = transform.position;
        target = transform.position + transform.up * speed;
        StartCoroutine("GoingStraightKoiogran");

    }

    IEnumerator GoingStraight()
    {
        while (Vector3.Distance(transform.position, target)>0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, target, 0.1f);
            yield return null;
        }


    }
    IEnumerator GoingStraightKoiogran()
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, target, 0.1f);
            yield return null;
        }
        transform.RotateAround(transform.position,Vector3.forward,180);

    }

    public void BarrelRoll(bool right)
    {
        if (right)
        {
            target = transform.TransformPoint(Vector3.right);

            StartCoroutine("Rolling");
        }
        else
        {
            target =transform.TransformPoint(Vector3.right * -1);

            StartCoroutine("Rolling");

        }

    }

    IEnumerator Rolling()
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, target, 0.1f);
            yield return null;
        }
     

    }

    // Til når du arbejder videre. Sæt alle tingene op og med længder osv og find en måde at flyve ligeudpå.
    //For juice sæt quaternions på.
    // En turn har halvt så stor svingarm som en bank

    void OnMouseDown()
    {
       FlightManager.GetComponent<FlightManager>().StartSetDirection(gameObject);
    }

    public void Turn(float speed, bool right)
    {
        float sped = speed;
        int rotaion = -1;
        if (!right)
        {
            sped -= speed * 2;
            rotaion = 1;
        }
        GameObject hejsa = Instantiate(thing, transform.TransformPoint(Vector3.right * sped), Quaternion.identity) as GameObject;
        hejsa.AddComponent<Rotations>().SetDegrees(90, rotaion);
        transform.SetParent(hejsa.transform);

    }

    public void Bank(float speed, bool right )
    {
        float sped = speed *2;
        int rotaion = -1;
        if (!right)
        {
            sped -= speed*4;
            rotaion = 1;
        }
        GameObject hejsa = Instantiate(thing, transform.TransformPoint(Vector3.right * sped), Quaternion.identity) as GameObject;
        hejsa.AddComponent<Rotations>().SetDegrees(45,rotaion);
        transform.SetParent(hejsa.transform);


    }

    public void BankSegnorLoop(float speed, bool right)
    {
        float sped = speed * 2;
        int rotaion = -1;
        if (!right)
        {
            sped -= speed * 4;
            rotaion = 1;
        }
        GameObject hejsa = Instantiate(thing, transform.TransformPoint(Vector3.right * sped), Quaternion.identity) as GameObject;
        hejsa.AddComponent<Rotations>().SetDegrees(45, rotaion);
        transform.SetParent(hejsa.transform);
        StartCoroutine(WaitAndTurn(0.7f, 180));
    }


    public void TurnTallonRoll(float speed, bool right)
    {
        float sped = speed;
        int rotaion = -1;
        if (!right)
        {
            sped -= speed * 2;
            rotaion = 1;
        }
        GameObject hejsa = Instantiate(thing, transform.TransformPoint(Vector3.right * sped), Quaternion.identity) as GameObject;
        hejsa.AddComponent<Rotations>().SetDegrees(90, rotaion);
        transform.SetParent(hejsa.transform);
        if (right)
        {
        StartCoroutine(WaitAndTurn(0.7f, -90));

        }
        else
        {
        StartCoroutine(WaitAndTurn(0.7f, 90));

        }

    }

    IEnumerator WaitAndTurn(float time, float degrees)
    {
        yield return new WaitForSeconds(time);
        transform.RotateAround(transform.position, Vector3.forward, degrees);

    }

    // Update is called once per frame
    void Update ()
    {

    }
}
