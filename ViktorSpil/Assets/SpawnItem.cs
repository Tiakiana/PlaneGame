using UnityEngine;
using System.Collections;

public class SpawnItem : MonoBehaviour
{
    public GameObject SpawnPrefab;
    public GameObject SpriteShadow;
	// Use this for initialization
	void Start () {
	
	}
	


	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
      
        ImClicked();
    }

    public void ImClicked()
    {
        SpawnManager.SpwnMngr.SetGameObject(SpawnPrefab);
        SpawnManager.SpwnMngr.SpawnSpriteShadow(SpriteShadow);
    }


}
