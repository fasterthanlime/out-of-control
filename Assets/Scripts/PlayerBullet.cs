using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {
    
	public string weaponColor = null;
	
	void Update ()
    {
        transform.Translate(0, 0, 10 * Time.deltaTime);
	}

	void OntriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag("Enemy")){
			other.gameObject.GetComponent<ColorShield>().GetHitByColor(weaponColor);
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
