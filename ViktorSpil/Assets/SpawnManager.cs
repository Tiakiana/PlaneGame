using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject ChosenTypeOfPawn;
    public static SpawnManager SpwnMngr;
    public GameObject sprite;


    void Awake()
    {
        SpwnMngr = this;
    }

  
	void Start () {
	
	}



    public void SetSprite(GameObject spr)
    {
        sprite = spr;

    }
    

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (sprite != null)
        {
            Debug.Log("Hej");
            sprite.gameObject.transform.position = camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10));
        }
        if (Input.GetMouseButtonUp(1) && ChosenTypeOfPawn!= null)
        {
            Destroy(sprite.gameObject); 
            sprite = null;
            InstantiatePrefab(camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10)));

            ChosenTypeOfPawn = null;
        }

    }

    public Camera camera;


    public void SpawnSpriteShadow(GameObject go)
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        Vector3 newVector = camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10));
        sprite = Instantiate(go, newVector, Quaternion.identity) as GameObject;


    }

    public void SetGameObject(GameObject go)
    {
        ChosenTypeOfPawn = go;
    }

    public void InstantiatePrefab(Vector3 vec)
    {
        Instantiate(ChosenTypeOfPawn, vec, Quaternion.identity);
    }


}
