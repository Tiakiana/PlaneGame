using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUITRAINING : MonoBehaviour {

    public int selGridInt = 0;
    public string[] selStrings = new string[] { "Turn Left 1", "Bank Left 1", "Straight 1", "Bank Right 1" , "Turn Right 1", "Turn Left 2", "Bank Left 2", "Straight 2", "Bank Right 2", "Turn Right 2" };
    public Image[] images;
    void OnGUI()
    {
        selStrings = new string[] { "Turn Left 1", "Bank Left 1", "Straight 1", "Bank Right 1", "Turn Right 1", "Turn Left 2", "Bank Left 2", "Straight 2", "Bank Right 2", "Turn Right 2" };
        GUILayout.BeginVertical("Box");
        selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings, 5);
        if (GUILayout.Button("Start"))
            Debug.Log("You chose " + selStrings[selGridInt]);
        Debug.Log("" + selGridInt);

        GUILayout.EndVertical();
    }
}
