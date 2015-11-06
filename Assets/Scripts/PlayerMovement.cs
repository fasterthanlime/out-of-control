using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    float triggerLeftValue;
    float triggerRightValue;
    public float Speed;
    public float maxYaw,maxRoll;
    public float camXswitch = 1.2f;
    public GameObject minimap;


    void Start ()
    {
	
	}
	
	void Update ()
    {
        triggerLeftValue = Input.GetAxis("TriggersR_1");
        triggerRightValue = Input.GetAxis("TriggersL_1");

        Vector3 velocity = new Vector3(triggerLeftValue- triggerRightValue, 0,0);
        Vector3 newPos = transform.position + velocity * Time.deltaTime * Speed;

        if (newPos.x<5&&newPos.x>-5)
        {
            transform.position = newPos;
        }

        transform.localRotation = Quaternion.Euler(0, (triggerLeftValue-triggerRightValue)* maxYaw,  - (triggerLeftValue - triggerRightValue) * maxRoll);
        if (transform.position.x < -camXswitch)
        {
            var rect = minimap.GetComponent<Camera>().rect;
            rect.x = -0.7f;
            minimap.GetComponent<Camera>().rect = rect;
        }
        if (transform.position.x > camXswitch)
        {
            var rect = minimap.GetComponent<Camera>().rect;
            rect.x = 0.7f;
            minimap.GetComponent<Camera>().rect = rect;
        }
    }
}
