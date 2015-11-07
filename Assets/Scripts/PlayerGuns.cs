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
	public GameObject Laser;
    public GameObject Plasma;
    public GameObject Mine;
	public string colorPower = "green";
	GameObject clone;
	public float ShotDelay=0.3f;
	private float _lCounter = 0;
	private float _rCounter = 0;

	void Start ()
	{
		
	}
	
	void Update ()
	{
        CheckWeaponChange();

		Transform oldLeft = LTurret;
		Transform oldRight = RTurret;

		if ((XCI.GetAxis (XboxAxis.RightStickX) < - precision) || (XCI.GetAxis (XboxAxis.RightStickX) > precision) || (XCI.GetAxis (XboxAxis.RightStickY) < - precision) || (XCI.GetAxis (XboxAxis.RightStickY) > precision)) {
			LTurret.localRotation = Quaternion.Lerp (oldLeft.localRotation, Quaternion.Euler (0, Mathf.Atan2 (XCI.GetAxis (XboxAxis.RightStickX), XCI.GetAxis (XboxAxis.RightStickY)) * 180 / Mathf.PI, 0), .5f);
		}
		if ((XCI.GetAxis (XboxAxis.LeftStickX) < - precision) || (XCI.GetAxis (XboxAxis.LeftStickY) > precision) || (XCI.GetAxis (XboxAxis.LeftStickY) < - precision) || (XCI.GetAxis (XboxAxis.LeftStickY) > precision)) {
			RTurret.localRotation = Quaternion.Lerp (oldRight.localRotation, Quaternion.Euler (0, Mathf.Atan2 (XCI.GetAxis (XboxAxis.LeftStickX), XCI.GetAxis (XboxAxis.LeftStickY)) * 180 / Mathf.PI, 0), .5f);
		}

		if (XCI.GetButton (XboxButton.RightStick))
        {
			if (_lCounter >= ShotDelay)
            {
				_lCounter = 0;
				
                switch (colorPower)
                {
                    case "green":
                        clone = (GameObject)Instantiate (Laser, LTurretHelper.position, LTurretHelper.rotation);
				        clone.GetComponent<PlayerBullet>().weaponColor = colorPower;
				        clone.GetComponent<PlayerBullet>().setColor();
                        break;
                    case "blue":
                        clone = (GameObject)Instantiate(Plasma, LTurretHelper.position, LTurretHelper.rotation);
                        clone.GetComponent<PlayerBullet>().weaponColor = colorPower;
                        clone.GetComponent<PlayerBullet>().setColor();
                        break;
                    case "red":
                        clone = (GameObject)Instantiate(Mine, LTurretHelper.position, LTurretHelper.rotation);
                        clone.GetComponent<PlayerBullet>().weaponColor = colorPower;
                        clone.GetComponent<PlayerBullet>().setColor();
                        break;
                    default:
                        break;
                }
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

		if (XCI.GetButton (XboxButton.LeftStick)) {
			if (_rCounter >= ShotDelay) {
				_rCounter = 0;
                switch (colorPower)
                {
                    case "green":
                        clone = (GameObject)Instantiate(Laser, RTurretHelper.position, RTurretHelper.rotation);
                        clone.GetComponent<PlayerBullet>().weaponColor = colorPower;
                        clone.GetComponent<PlayerBullet>().setColor();
                        break;
                    case "blue":
                        clone = (GameObject)Instantiate(Plasma, RTurretHelper.position, RTurretHelper.rotation);
                        clone.GetComponent<PlayerBullet>().weaponColor = colorPower;
                        clone.GetComponent<PlayerBullet>().setColor();
                        break;
                    case "red":
                        clone = (GameObject)Instantiate(Mine, RTurretHelper.position, RTurretHelper.rotation);
                        clone.GetComponent<PlayerBullet>().weaponColor = colorPower;
                        clone.GetComponent<PlayerBullet>().setColor();
                        break;
                    default:
                        break;
                }
            } else {
				_rCounter += Time.deltaTime;
			}
		} else {
			_rCounter = 0;
		}
	}

	void setColor (){
		if (colorPower == "Green") {
			
		}
		if (colorPower == "Red") {
			
		}
		if (colorPower == "Blue") {
			
		}
		if (colorPower == "Yellow") {
			
		}
	}

    void CheckWeaponChange()
    {
        if (XCI.GetButton(XboxButton.A))
        {
            colorPower = "green";
            ShotDelay = .2f;
            _lCounter = 0;
            _rCounter = 0;
        }
        else if (XCI.GetButton(XboxButton.X))
        {
            colorPower = "blue";
            ShotDelay = .6f;
            _lCounter = 0;
            _rCounter = 0;
        }
        else if (XCI.GetButton(XboxButton.B))
        {
            colorPower = "red";
            ShotDelay = 1f;
            _lCounter = 0;
            _rCounter = 0;
        }
        
    }
}
