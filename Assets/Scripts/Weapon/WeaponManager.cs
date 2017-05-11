using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
    public Weapon[] weapons;

    private int actualWeapon;

	// Use this for initialization
	void Start () {
        this.actualWeapon = 0;

        this.SwitchWeapon();
	}
	
	// Update is called once per frame
	void Update () {
        if (this.actualWeapon == 0 && Input.GetMouseButton(1))
        {
            this.actualWeapon = 1;
            this.SwitchWeapon();
            Debug.Log("Pressed right click.");
            return;
        }
        else if (this.actualWeapon == 1 && Input.GetMouseButton(1))
        {

            this.actualWeapon = 0;
            this.SwitchWeapon();
            Debug.Log("Pressed right click.");
            return;
        }

	}

    void SwitchWeapon()
    {
        for (int i = 0; i < this.weapons.Length; i++)
        {
            this.weapons[i].gameObject.SetActive(false);
        }

       this.weapons[this.actualWeapon].gameObject.SetActive(true);
    }
}
