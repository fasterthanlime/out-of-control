using UnityEngine;
using System.Collections;

public class ShowResult : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2, 200, 50),"");
    }

}
