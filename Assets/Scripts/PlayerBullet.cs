using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {
    
	void Start ()
    {
	}
	
	void Update ()
    {
        transform.Translate(0, 10 * Time.deltaTime, 0);
	}
}
