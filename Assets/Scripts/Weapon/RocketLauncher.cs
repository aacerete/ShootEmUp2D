using UnityEngine;

public class RocketLauncher : Weapon {

    public GameObject rocketPRFB;
	// Use this for initialization
	void Start () {
        this.maxAmmunition = 10;
        this.currentAmmunition = this.maxAmmunition;
        this.coolDownTime = .2f;
        this.time = this.coolDownTime;
        this.damage = -100;

        GameMaster.current.weaponIcon.sprite = this.weaponIcon;
        GameMaster.current.weaponAmmo.text = this.currentAmmunition + "/" + this.maxAmmunition;
    }



}
 