using UnityEngine;
using System.Collections;

public class MarkerFade : MonoBehaviour {

    public SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }

    void Activate()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    public void Starter()
    {
        StartCoroutine("FadeInOut");
    }

    public IEnumerator FadeInOut()
    {
        StartCoroutine("FadeIn");
        yield return new WaitForSeconds(3);
        StopCoroutine("FadeIn");

        StartCoroutine("Fadeout");


    }

    public IEnumerator Fadeout()
    {
        while (sr.color.a>0)
        {
            Color r;
            r = sr.color;
            float hubert = sr.color.a;
            hubert -= 0.01f;
            r.a = hubert;
            sr.color = r;
            yield return null;
        }
    }

    public IEnumerator FadeIn()
    {
        while (sr.color.a < 1)
        {
            Color r;
            r = sr.color;
            float hubert = sr.color.a;
            hubert += 0.1f;
            r.a = hubert;
            sr.color = r;
            yield return null;
        }
    }

    void Update () {
	//Debug.Log(sr.color.a);
	}
}
