using UnityEngine;
using System.Collections;

public class BGMusic : MonoBehaviour {

    public AudioSource source;
    public AudioClip clip;

	// Use this for initialization
	void Start () {
        source.loop = true;
        source.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
