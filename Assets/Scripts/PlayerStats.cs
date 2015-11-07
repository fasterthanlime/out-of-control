using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public int MaxHealth;
    public int CurrentHealth;
    public int Score;
    public GameObject SmallExplosion;

	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (CurrentHealth<=0)
        {
            PlayerPrefs.SetInt("Score", Score);
            Application.LoadLevel("Menu");
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="EBullet")
        {
            CurrentHealth-=other.GetComponent<EnemyBullet>().Damage;
            Instantiate(SmallExplosion, other.transform.position, other.transform.rotation);
        }
    }

    void OnGUI()
    {
        GUI.backgroundColor = Color.red;
        GUI.Label(new Rect(20, Screen.height - 50, MaxHealth, 30), "");
    }

}
