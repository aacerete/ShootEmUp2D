using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour {

    public float flySpeed;
    private Rigidbody2D rbody;
    protected Weapon weapon;

	void Start () {
		
	}
	

	void Update () {
        this.rbody = GetComponent<Rigidbody2D>();
        this.rbody.velocity = this.transform.up * this.flySpeed;
	}

    public void SetWeapon (Weapon _weapon)
    {
        this.weapon = _weapon;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        this.OnCollision(other.gameObject);
        Destroy(this.gameObject);
    }

    protected virtual void OnCollision(GameObject obj)
    {
        Entity entity = obj.GetComponent<Entity>();
        if (entity != null)
        {
            this.weapon.OnHit(entity);
        }
    }
}
