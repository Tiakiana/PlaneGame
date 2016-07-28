using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderScr : MonoBehaviour
{
    private GameObject Plane;
    private Slider slider;
    // Use this for initialization
	void Start ()
	{
	    slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetRotation()
    {
        Plane.transform.localEulerAngles = new Vector3(0, 0, slider.value);
    }

    public void SetPlane(GameObject go)
    {
        Plane = go;
    }

}
