using UnityEngine;
using System.Collections;

public class DestroybyTime : MonoBehaviour {


	void Start () {
		StartCoroutine (Destroy());
	}

	IEnumerator Destroy (){
		yield return new WaitForSeconds (3);
		Destroy (gameObject);
	}

}
