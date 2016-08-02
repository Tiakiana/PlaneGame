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
        // C# or UnityScript
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (sprite != null)
        {
            if (d > 0f)
            {
                //Debug.Log("Mouse Down" + Input.GetAxis("Mouse ScrollWheel"));
                sprite.transform.RotateAround(sprite.transform.position, sprite.transform.forward, Input.GetAxis("Mouse ScrollWheel") * 100f);
            }
            else if (d < 0f)
            {
                //Debug.Log("Mouse Down" + Input.GetAxis("Mouse ScrollWheel"));
                sprite.transform.RotateAround(sprite.transform.position, sprite.transform.forward, Input.GetAxis("Mouse ScrollWheel") * 100f);
            }

        }


        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (sprite != null)
        {
          //  Debug.Log("Hej");
            sprite.gameObject.transform.position = camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10));
        }
        if (Input.GetMouseButtonUp(1) && ChosenTypeOfPawn!= null)
        {
            
            InstantiatePrefab(camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10)),sprite.transform.eulerAngles);
            Destroy(sprite.gameObject);
            sprite = null;
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
    public void InstantiatePrefab(Vector3 vec, Vector3 eul)
    {
        GameObject go = Instantiate(ChosenTypeOfPawn, vec, Quaternion.identity) as GameObject;
        go.transform.eulerAngles = eul;
    }


}
