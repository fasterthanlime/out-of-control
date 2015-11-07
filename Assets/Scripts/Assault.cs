using UnityEngine;
using System.Collections;

public class Assault : MonoBehaviour {

    public enum EnemyState
    {
        JumpingIn,
        Persuing
    }

    private float YSpeed = 2;
    private float xSpeed = 3;
    public int Health = 100;
    int direction;
    private GameObject Player;
    public EnemyState EState = EnemyState.JumpingIn;

	void Start ()
    {
        if (transform.position.x > 0)
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
        switch (EState)
        {
            case EnemyState.JumpingIn:JumpInUpdate();
                break;
            case EnemyState.Persuing:PersueUpdate();
                break;
            default:
                break;
        }
	}

    void JumpInUpdate()
    {
        if (transform.position.z <= -15)
        {
            EState = EnemyState.Persuing;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 10.2f, -16),.05f);
        }
    }

    void PersueUpdate()
    {
        // move
        if (transform.position.x + direction * xSpeed * Time.deltaTime > 4.5 ||
            transform.position.x + direction * xSpeed * Time.deltaTime < -4.5)
        {
            direction *= -1;
        }
        else
        {
            transform.Translate(new Vector3(direction * xSpeed, 0, YSpeed) * Time.deltaTime);
        }

        // check death
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
