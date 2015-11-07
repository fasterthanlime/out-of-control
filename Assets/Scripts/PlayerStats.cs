using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public int MaxHealth;
    public int CurrentHealth;
    public int Score;

	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (CurrentHealth<=0)
        {
            PlayerPrefs.SetInt("Score", Score);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="EBullet")
        {
            CurrentHealth-=other.GetComponent<EnemyBullet>().Damage;
        }
    }


}
