using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {
    
	public string weaponColor = null;
    public int Damage;
    public int Speed;
    public GameObject SmallExplosion;

	void Update ()
    {
        transform.Translate(0, 0, Speed * Time.deltaTime);
	}

	void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")){
			other.gameObject.GetComponent<enemyHealth>().health -= Damage;
            Instantiate(SmallExplosion, transform.position, transform.rotation);
		}
	}

	public void setColor (){
		if (weaponColor == "Green") {
		
		}
		if (weaponColor == "Red") {
			
		}
		if (weaponColor == "Blue") {
			
		}
		if (weaponColor == "Yellow") {
			
		}
	}
}
