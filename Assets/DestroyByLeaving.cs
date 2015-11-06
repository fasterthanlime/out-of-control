using UnityEngine;
using System.Collections;

public class DestroyByLeaving : MonoBehaviour {


	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag != "Cylinder") {
			Destroy (other.gameObject);
		}
	}
}
