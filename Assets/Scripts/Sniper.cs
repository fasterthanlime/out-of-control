using UnityEngine;
using System.Collections;

public class Sniper : MonoBehaviour {

    private GameObject Player;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetPlayerRef(GameObject player)
    {
        Player = player;
    }
}
