using UnityEngine;
using System.Collections;

public class Assault : MonoBehaviour {

    private float YSpeed = 0.2f;
    private float xSpeed = 4;
    public int Health = 100;
    int direction;
    private GameObject Player;

	void Start ()
    {
        if (transform.position.x>0)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
	}

    public void SetPlayerRef(GameObject player)
    {
        Player = player;
    }

	
	void Update ()
    {
        //move
        if (transform.position.x+direction*xSpeed*Time.deltaTime>4.5|| transform.position.x + direction * xSpeed * Time.deltaTime < -4.5)
        {
            direction *= -1;
        }
        else
        {
            transform.Translate(new Vector3(direction * xSpeed, 0, YSpeed) * Time.deltaTime);
        }

        //check death
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
	}
}
