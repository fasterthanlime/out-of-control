using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

    public GameObject Player;

    //enemy classes
    public GameObject Assault;
    public GameObject Bomber;
    public GameObject Sniper;

    //manager vars
    private float _counter;
    public int SecondsBetweenWaves;

	// Use this for initialization
	void Start () {
        SpawnWave();
    }
	
	// Update is called once per frame
	void Update () {
        if (_counter> SecondsBetweenWaves)
        {
            _counter = 0;
            SpawnWave();
        }
        else
        {
            _counter += Time.deltaTime;
        }
	}

    void CreateAssault(Vector3 pos)
    {
        GameObject foo = (GameObject)Instantiate(Assault, pos, Quaternion.Euler(0, 0, 0));
        foo.GetComponent<Assault>().SetPlayerRef(Player);
    }


    void CreateBomber(Vector3 pos)
    {
        GameObject foo = (GameObject)Instantiate(Bomber, pos, Quaternion.Euler(0, 0, 0));
        foo.GetComponent<Bomber>().SetPlayerRef(Player);
    }

    void CreateSniper(Vector3 pos,float jumpSpeed)
    {
        GameObject foo = (GameObject)Instantiate(Sniper, pos, Quaternion.Euler(0, 0, 0));
        foo.GetComponent<Sniper>().SetPlayerRef(Player);
        foo.GetComponent<Sniper>().SetJumpSpeed(jumpSpeed);
    }

    void SpawnWave()
    {
        Debug.Log("hit");
        int waveID = Random.Range(0, 3);

        switch (waveID)
        {
            case 0:                     //Sniper wave
                CreateSniper(new Vector3(-30, 0, 60), 0.06f);
                CreateSniper(new Vector3(30, 0, 60), 0.08f);
                CreateSniper(new Vector3(-30, 0, 60), 0.1f);
                break;
            case 1:                     //Assault wave
                CreateAssault(new Vector3(.5f, 12, 7));
                CreateAssault(new Vector3(-.5f, 12, 7));
                CreateAssault(new Vector3(2f, 13, 7));
                CreateAssault(new Vector3(-2f, 13, 7));
                break;
            case 2:                     //Single bomber wave
                int x = Random.Range(-4,5);
                CreateBomber(new Vector3(x, 14, 9));
                break;
            default:
                break;
        }
    }
}
