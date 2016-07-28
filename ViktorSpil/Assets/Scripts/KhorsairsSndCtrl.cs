using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KhorsairsSndCtrl : MonoBehaviour
{
    private AudioSource audi;
    public List<AudioClip> Musics = new List<AudioClip>();
    private int music;
    private int musiclast;
	// Use this for initialization
	void Start ()
	{
	    audi = GetComponent<AudioSource>();
	    music = Random.Range(0, 3);
	    musiclast = music;

	}
	
	// Update is called once per frame
	void Update ()
	{
       
        if (!audi.isPlaying)
	    {
            StartHere:
            music = Random.Range(0, 3);
            if (music == musiclast)
            {
                goto StartHere;
            }
            else
            {
                musiclast = music;
                audi.clip = Musics[music];
                audi.Play();
            }
        }
	}
}
