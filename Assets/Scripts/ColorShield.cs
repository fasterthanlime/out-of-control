using UnityEngine;
using System.Collections;

public class ColorShield : MonoBehaviour {

	string shieldColor = null;

	public void GetHitByColor (string hitColor)
	{
		if (hitColor == shieldColor) {
			Destroy (gameObject);
		}
	}
}
