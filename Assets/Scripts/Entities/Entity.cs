using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    public int maxHealth;
    public int health;

	// Use this for initialization
	void Start () {
        this.health = maxHealth;

	}
	
	// Update is called once per frame
	public virtual void ModifyHealth (int amount) {
        this.health += amount;

        if(this.health <= 0)
        {
            this.health = 0;
            this.OnDeath();
        }else if(this.health > this.maxHealth){
            this.health = maxHealth;
        }
	}

    public virtual void OnDeath()
    {
        Destroy(this.gameObject);
    }

}
