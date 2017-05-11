using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon {

    public GameObject blasterShoot;
    // Use this for initialization
    void Start()
    {
        this.maxAmmunition = 300;
        this.currentAmmunition = this.maxAmmunition;
        this.coolDownTime = .1f;
        this.time = this.coolDownTime;
        this.damage = -10;

        GameMaster.current.weaponIcon.sprite = this.weaponIcon;
        GameMaster.current.weaponAmmo.text = this.currentAmmunition + "/" + this.maxAmmunition;
    }


}