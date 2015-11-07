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
    public GameObject BulletClass;
    public int NumberOfBullets = 5;

    private float _shotgunCounter = 0, _missileCounter = 0;

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

        //shotgun timing
        if (_shotgunCounter>=5)
        {
            _shotgunCounter = 0;
            FireShotgun();
        }
        else
        {
            _shotgunCounter += Time.deltaTime;
        }

        //missile timiing
        if (_missileCounter >= 2)
        {
            _missileCounter = 0;
        }
        else
        {
            _missileCounter += Time.deltaTime;
        }

        // check death
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerRef(GameObject player)
    {
        Player = player;
    }

    void FireShotgun()
    {
        for (int i = 0; i < NumberOfBullets; i++)
        {
            GameObject obj = (GameObject)Instantiate(BulletClass, transform.position, transform.rotation);
            obj.transform.LookAt(Player.transform.position);
            obj.transform.Rotate(0, Random.Range(-15, 16), 0);
            obj.GetComponent<EnemyBullet>().Damage = 20;
            obj.GetComponent<EnemyBullet>().Speed = 0.4f;
        }

        
    }
}
