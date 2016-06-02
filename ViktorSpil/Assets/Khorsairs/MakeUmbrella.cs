using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MakeUmbrella : MonoBehaviour
{
    private LineRenderer lr;
    private float Length;
    public int Distance;
	// Use this for initialization
	void Start ()
	{
	    lr = GetComponent<LineRenderer>();
        DrawUmbrella(Distance);

	}

    public void DrawUmbrella(int leng)
    {
        List<Vector3> vectors = new List<Vector3>();

        if (leng ==3)
        {
            Length = 7.5f;
            float x = -5.3f;
            for (int i = 0; i < 54; i++)
            {
                float y = Mathf.Sqrt((Mathf.Pow(Length, 2)) - (Mathf.Pow(x, 2)));

                vectors.Add(new Vector2(x, y));

                x += 0.2f;
            }
            
        }
        if (leng == 2)
        {
            Length = 5;
            float x = -3.54f;
            for (int i = 0; i < 36; i++)
            {
                float y = Mathf.Sqrt((Mathf.Pow(Length, 2)) - (Mathf.Pow(x, 2)));

                vectors.Add(new Vector2(x, y));

                x += 0.2f;
            }
        }
        
        lr.SetPositions(vectors.ToArray());
        

    }

    // Update is called once per frame
	void Update () {
	
	}
}
