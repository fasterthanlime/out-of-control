using UnityEngine;
using System.Collections;

public class PlayerMovementPhysics : MonoBehaviour {

    float triggerLeftValue;
    float triggerRightValue;
    public float Speed;
    public float maxYaw,maxRoll;
	public float xMin, xMax;
	public float camXswitch;
	public Camera minimap;
	Rigidbody rb;
	bool rightPos;

    void Start ()
    {
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update ()
    {
        triggerLeftValue = Input.GetAxis("TriggersR_1");
        triggerRightValue = Input.GetAxis("TriggersL_1");

        float axesVelocity = triggerLeftValue - triggerRightValue;
		rb.velocity =  new Vector3 (- axesVelocity * Time.deltaTime * Speed, 0.0f, 0.0f);

		Vector3 position = new Vector3 (Mathf.Clamp (transform.position.x, xMin, xMax), transform.position.y, transform.position.z);
		transform.position = position;

        transform.localRotation = Quaternion.Euler(0, (triggerLeftValue-triggerRightValue)* maxYaw, -90 - (triggerLeftValue - triggerRightValue) * maxRoll);

		if (transform.position.x < - camXswitch)
		{
			var rect = minimap.GetComponent<Camera>().rect;
			rect.x = -0.7f;
			minimap.GetComponent<Camera>().rect = rect;
		}
		if (transform.position.x > camXswitch) {
			var rect = minimap.GetComponent<Camera>().rect;
			rect.x = 0.7f;
			minimap.GetComponent<Camera>().rect = rect;
		}
    }
}
