using UnityEngine;
using System.Collections;

public class Bomber : MonoBehaviour {

    public enum EnemyState
    {
        JumpingIn,
        Persuing
    }

    public int Health = 500;
    private GameObject Player;
    public EnemyState EState = EnemyState.JumpingIn;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        switch (EState)
        {
            case EnemyState.JumpingIn:
                JumpInUpdate();
                break;
            case EnemyState.Persuing:
                PersueUpdate();
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
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 11.2f, -16), .04f);
        }
    }

    void PersueUpdate()
    {
        float sine = transform.position.y + .01f*Mathf.Sin(3 * Time.time);
        transform.position = new Vector3(transform.position.x, sine, transform.position.z);
    }

    public void SetPlayerRef(GameObject player)
    {
        Player = player;
    }
}
