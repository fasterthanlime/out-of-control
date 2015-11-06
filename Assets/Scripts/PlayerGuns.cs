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
		OrientTurret (XboxAxis.LeftStickX, XboxAxis.LeftStickY, RTurret);
		OrientTurret (XboxAxis.RightStickX, XboxAxis.RightStickY, LTurret);

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

	public void OrientTurret (XboxAxis xAxis, XboxAxis yAxis, Transform turret)
	{
		var x = XCI.GetAxis (xAxis);
		var y = XCI.GetAxis (yAxis);
		var t = .5f;

		if (x > -precision && x < precision && y > -precision && y < precision) {
			return;
		}

		var angleY = Mathf.Atan2 (x, y) * Mathf.Rad2Deg;
		var newRotation = Quaternion.Euler (0, angleY, 0);
		turret.localRotation = Quaternion.Lerp (turret.localRotation, newRotation, t);
	}
}
