using XboxCtrlrInput;
using UnityEngine;
using System.Collections;

public class Start : MonoBehaviour {

    private float _counter;
    bool a = false;

	public void Update () {
		if (XCI.GetButton (XboxButton.A)) {
            a = true;
			
		}
        if (a)
        {
            _counter += Time.deltaTime;
        }
        if (_counter>=1.5f)
        {
            Application.LoadLevel ("Main");
        }
	}
}
