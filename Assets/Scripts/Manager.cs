using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

    public GameObject Player;

    public GameObject Assault;
    public GameObject Bomber;
    public GameObject Sniper;


	// Use this for initialization
	void Start () {
        CreateAssault(new Vector3(.5f,12,7));
        CreateAssault(new Vector3(-.5f, 12, 7));
        CreateAssault(new Vector3(2f, 13, 7));
        CreateAssault(new Vector3(-2f, 13, 7));

        CreateBomber(new Vector3(0,14,9));
    }
	
	// Update is called once per frame
	void Update () {
	
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

    void CreateSniper(Vector3 pos)
    {
        GameObject foo = (GameObject)Instantiate(Sniper, pos, Quaternion.Euler(0, 0, 0));
        foo.GetComponent<Sniper>().SetPlayerRef(Player);
    }
}
