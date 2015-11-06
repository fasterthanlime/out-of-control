using XboxCtrlrInput;
using UnityEngine;
using System.Collections;

public class PlayerGuns : MonoBehaviour
{

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

		if ((XCI.GetAxis (XboxAxis.RightStickX) < - precision) || (XCI.GetAxis (XboxAxis.RightStickX) > precision) || (XCI.GetAxis (XboxAxis.RightStickY) < - precision) || (XCI.GetAxis (XboxAxis.RightStickY) > precision)) {
			LTurret.localRotation = Quaternion.Lerp (oldLeft.localRotation, Quaternion.Euler (0, Mathf.Atan2 (XCI.GetAxis (XboxAxis.RightStickX), XCI.GetAxis (XboxAxis.RightStickY)) * 180 / Mathf.PI, 0), .5f);
		}
		if ((XCI.GetAxis (XboxAxis.LeftStickX) < - precision) || (XCI.GetAxis (XboxAxis.LeftStickY) > precision) || (XCI.GetAxis (XboxAxis.LeftStickY) < - precision) || (XCI.GetAxis (XboxAxis.LeftStickY) > precision)) {
			RTurret.localRotation = Quaternion.Lerp (oldRight.localRotation, Quaternion.Euler (0, Mathf.Atan2 (XCI.GetAxis (XboxAxis.LeftStickX), XCI.GetAxis (XboxAxis.LeftStickY)) * 180 / Mathf.PI, 0), .5f);
		}

		if (XCI.GetButton (XboxButton.RightStick)) {
			if (_lCounter >= ShotDelay) {
				_lCounter = 0;
				Instantiate (BulletClass, LTurretHelper.position, LTurretHelper.rotation);
			} else {
				_lCounter += Time.deltaTime;
			}
		} else {
			_lCounter = 0;
		}

		if (XCI.GetButton (XboxButton.LeftStick)) {
			if (_rCounter >= ShotDelay) {
				_rCounter = 0;
				Instantiate (BulletClass, RTurretHelper.position, RTurretHelper.rotation);
			} else {
				_rCounter += Time.deltaTime;
			}
		} else {
			_rCounter = 0;
		}
	}
}
