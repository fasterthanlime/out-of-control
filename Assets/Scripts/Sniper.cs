using UnityEngine;
using System.Collections;

public class Sniper : MonoBehaviour {

    public enum EnemyState
    {
        JumpingIn,
        Dodging,
        Shooting
    }

    private GameObject Player;
    public EnemyState EState = EnemyState.JumpingIn;
    private Vector3 targetPos =new Vector3(-0, 10.2f, -12);
    private float _Counter = 0;
    private float JumpSpeed = 0.05f;

    // Use this for initialization
    void Start () {
    }

    public void SetJumpSpeed(float jSpeed)
    {
        JumpSpeed = jSpeed;
    }


	// Update is called once per frame
	void Update ()
    {
        switch (EState)
        {
            case EnemyState.JumpingIn:JumpInUpdate();

                break;
            case EnemyState.Dodging:DodgeUpdate();
                break;
            case EnemyState.Shooting:ShootUpdate();
                break;
            default:
                break;
        }
    }

    void JumpInUpdate()
    {
        if (transform.position.z <= -11)
        {
            EState = EnemyState.Dodging;

            int x = Random.Range(-5, 6);
            int z = Random.Range(-10, -14);
            targetPos = new Vector3(x, 10.2f, z);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetPos,JumpSpeed);
        }
    }

    void ShootUpdate()
    {
        if (_Counter>=1.5f)
        {
            _Counter = 0;
            Fire();
            int x;
            if (transform.position.x>0)
            {
                x = Random.Range(-5, 0);
            }
            else
            {
                x = Random.Range(1, 6);
            }
            int z = Random.Range(-10, -14);
            targetPos = new Vector3(x, 10.2f, z);
            EState = EnemyState.Dodging;
        }
        else
        {
            _Counter += Time.deltaTime;
        }
    }

    void Fire()
    {

    }

    void DodgeUpdate()
    {
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            EState = EnemyState.Shooting;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, .05f);
        }

    }

    public void SetPlayerRef(GameObject player)
    {
        Player = player;
    }
}
