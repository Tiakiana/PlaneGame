using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlightManager : MonoBehaviour
{
    public GameObject PointOfOrigin;
    public GameObject Direction;
    public GameObject PlaneGameObject;
    public Slider SliderHere;
    private XWingMovement movement;
    // Use this for initialization
	void Start ()
	{
	    Direction = PointOfOrigin.transform.FindChild("SelectDirection").gameObject;
	}

    public void StartSetDirection(GameObject plane)
    {
        PlaneGameObject = plane;
        Direction.gameObject.SetActive(true);
        movement = PlaneGameObject.GetComponent<XWingMovement>();
        PointOfOrigin.transform.position = Input.mousePosition;
        // SliderHere.value = plane.transform.rotation

    }

    public void DoABarrelRoll(bool right)
    {
        movement.BarrelRoll(right);
    }

    public void ToggleAim()
    {
        PlaneGameObject.GetComponent<Inventory>().ToggleAim();
    }

    public void TurnPlaneRightTallonRoll(float speed)
    {
        movement.TurnTallonRoll(speed,true);
    }

    public void TurnPlaneLeftTallonRoll(float speed)
    {
        movement.TurnTallonRoll(speed,false);
    }

    public void BankPlaneRightSegnorLoop(float speed)
    {
        movement.BankSegnorLoop(speed,true);
    }

    public void BankPlaneLeftSegnorLoop(float speed)
    {
        movement.BankSegnorLoop(speed,false);
    }


    public void TurnPlaneLeft(float speed)
    {
        
                movement.Turn(speed,false);
        }

    public void TurnPlaneRight(float speed)
    {

        movement.Turn(speed, true);

    }

    public void BankPlaneLeft(float speed)
    {

        movement.Bank(speed, false);
    }

    public void BankPlaneRight(float speed)
    {
        movement.Bank(speed, true);


    }

    public void FlyPlaneStraight(float speed)
    {
        movement.Straight(speed);
    }

    public void FlyPlaneStraightKoiogran(float speed)
    {
        movement.StraightKoiogran(speed);
    }

    public void CallPlaneAndChildren()
    {
        PlaneGameObject.BroadcastMessage("TestRangeNear");
     //   PlaneGameObject.BroadcastMessage("FadeInOut");
    }


    // Update is called once per frame
    void Update () {
      
    }
}
