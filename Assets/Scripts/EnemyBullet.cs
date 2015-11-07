using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

    public int Damage=25;
    public float Speed = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, Speed * Time.deltaTime);
    }
}
