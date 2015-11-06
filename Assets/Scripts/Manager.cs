using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

    public GameObject Player;

    public GameObject Assault;


	// Use this for initialization
	void Start () {

        GameObject foo = (GameObject)Instantiate(Assault, new Vector3(-2f, 10.2f, -5.5f), Quaternion.Euler(0, 0, 0));
        GameObject bar = (GameObject)Instantiate(Assault, new Vector3(2f, 10.2f, -5.5f), Quaternion.Euler(0, 0, 0));

        foo.GetComponent<Assault>().SetPlayerRef(Player);
        bar.GetComponent<Assault>().SetPlayerRef(Player);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
