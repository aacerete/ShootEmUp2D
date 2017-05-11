using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Sprite weaponIcon;
    public Transform shootPoint;
    public GameObject proyectilePrfb;

    protected int currentAmmunition;
    protected int maxAmmunition;
    protected int damage;
    protected float time;
    protected float coolDownTime;
    // protected bool canShoot;

    private void OnEnable()
    {
        if (GameMaster.current != null)
        {
            GameMaster.current.weaponIcon.sprite = this.weaponIcon;
            GameMaster.current.weaponAmmo.text = this.currentAmmunition + "/" + this.maxAmmunition;
        }

      
    }

    // Update is called once per frame
    void Update() {
        if (this.time < this.coolDownTime)
        {
            this.time += Time.deltaTime;
        } else if (Input.GetMouseButton(0))
        {
            this.time = 0;
            if(this.currentAmmunition > 0)
            {
                this.Shoot();
                this.currentAmmunition--;
                GameMaster.current.weaponAmmo.text = this.currentAmmunition + "/" + this.maxAmmunition;
            }
            
        }
    }

        protected virtual void Shoot()
    {
        GameObject proyectile = Instantiate(this.proyectilePrfb, this.shootPoint.position, this.shootPoint.rotation);
        proyectile.GetComponent<Proyectile>().SetWeapon(this);
    }
    public virtual void OnHit(Entity obj)
    {
        obj.ModifyHealth(this.damage);
    }
}
