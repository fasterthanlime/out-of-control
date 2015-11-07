using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {



	public int health;
	public GameObject explosion;



	void Update () {
		if (health <= 0) {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
