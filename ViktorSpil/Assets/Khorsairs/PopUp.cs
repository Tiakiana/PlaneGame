using UnityEngine;
using System.Collections;
using System.Security.Policy;
using JetBrains.Annotations;

public class PopUp : MonoBehaviour
{
    public bool showTurn;
    public bool showPopUp;
	// Use this for initialization
	void Start ()
	{
        
	    showPopUp = false;
	}

    void OnMouseDown()
    {
        showPopUp = true;
    }


    // Update is called once per frame
	void Update ()
	{
	 
	}

    void OnGUI()
    {
        if (showPopUp)
        {
            GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
                   , 300, 250), ShowGUI, "Invalid word");

        }
        if (showTurn)
        {
            GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
                     , 300, 250), ShowGUI, "Invalid word");
        }

    }
    int selGridInt = 0;
    void ShowGUI(int windowID)
    {
        
          string[] selStrings = new string[] { "Turn Left", "Bank Left", "Straight", "Bank Right", "Turn Right" };
     

          selGridInt = GUI.SelectionGrid(new Rect(25, 25, 100, 30), selGridInt, selStrings, 5);
     
         
          if (GUI.Button(new Rect(50, 150, 75, 30), "OK"))
          {
              showPopUp = false;
              if (selGridInt == 0)
              {
                  showTurn = true;
              }
          }
   
    }

    void ShowTurn()
    {
        string[] selStrings = new string[] { "1", "2", "3"};


        selGridInt = GUI.SelectionGrid(new Rect(25, 25, 100, 30), selGridInt, selStrings, 1);


        if (GUI.Button(new Rect(50, 150, 75, 30), "OK"))
        {
            showTurn = false;

        }
    }

}
