using UnityEngine;
using System.Collections;

public class PlayerGuns : MonoBehaviour {

	public float precision;
    public Transform LTurret;
    public Transform RTurret;
    public Transform LTurretHelper;
    public Transform RTurretHelper;
    public GameObject BulletClass;
    public float ShotDelay;

    private float _lCounter = 0;
    private float _rCounter = 0;

    void Start ()
    {
	
	}
	
	void Update ()
    {
         

        Transform oldLeft = LTurret;
        Transform oldRight = RTurret;

		if ((Input.GetAxis ("R_XAxis_1") < - precision) || (Input.GetAxis ("R_XAxis_1") > precision) || (Input.GetAxis ("R_YAxis_1") < - precision) || (Input.GetAxis ("R_YAxis_1") > precision)){
			LTurret.localRotation = Quaternion.Lerp (oldLeft.localRotation, Quaternion.Euler (0,Mathf.Atan2 (Input.GetAxis ("R_XAxis_1"), -Input.GetAxis ("R_YAxis_1")) * 180 / Mathf.PI, 0), .5f);
		}
		if ((Input.GetAxis ("L_XAxis_1") < - precision) || (Input.GetAxis ("L_XAxis_1") > precision) || (Input.GetAxis ("L_YAxis_1") < - precision) || (Input.GetAxis ("L_YAxis_1") > precision)){
		RTurret.localRotation = Quaternion.Lerp (oldRight.localRotation, Quaternion.Euler (0,Mathf.Atan2 (Input.GetAxis ("L_XAxis_1"), -Input.GetAxis ("L_YAxis_1")) * 180 / Mathf.PI, 0), .5f);
		}

        if (Input.GetAxis("RS_1") > 0)
        {
            if (_lCounter>=ShotDelay)
            {
                _lCounter = 0;
                Instantiate(BulletClass, LTurretHelper.position,LTurretHelper.rotation);
            }
            else
            {
                _lCounter += Time.deltaTime;
            }
        }
        else
        {
            _lCounter = 0;
        }

        if (Input.GetAxis("LS_1") > 0)
        {
            if (_rCounter >= ShotDelay)
            {
                _rCounter = 0;
                Instantiate(BulletClass, RTurretHelper.position, RTurretHelper.rotation);
            }
            else
            {
                _rCounter += Time.deltaTime;
            }
        }
        else
        {
            _rCounter = 0;
        }
    }
}
