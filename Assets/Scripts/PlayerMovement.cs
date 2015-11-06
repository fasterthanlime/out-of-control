using XboxCtrlrInput;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    float triggerLeftValue;
    float triggerRightValue;
    public float Speed;
    public float maxYaw,maxRoll;
    public float camXswitch = 1.2f;


    void Start ()
    {
	
	}
	
	void Update ()
    {
        triggerLeftValue = XCI.GetAxis(XboxAxis.RightTrigger);
		triggerRightValue = XCI.GetAxis(XboxAxis.LeftTrigger);

        Vector3 velocity = new Vector3(triggerLeftValue- triggerRightValue, 0,0);
        Vector3 newPos = transform.position + velocity * Time.deltaTime * Speed;

        if (newPos.x<5&&newPos.x>-5)
        {
            transform.position = newPos;
        }

        transform.localRotation = Quaternion.Euler(0, (triggerLeftValue-triggerRightValue)* maxYaw,  - (triggerLeftValue - triggerRightValue) * maxRoll);
    }
}
