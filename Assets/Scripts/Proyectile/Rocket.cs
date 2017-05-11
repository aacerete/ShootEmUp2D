
using UnityEngine;

public class Rocket : Proyectile
{
    public GameObject explosionPrfb;
    public float explosionRadius = 1;
    // Use this for initialization
    protected override void OnCollision(GameObject obj)
    {
        base.OnCollision(obj);
        Collider2D[] objects;

        objects = Physics2D.OverlapCircleAll(this.transform.position, this.explosionRadius);

        if (objects.Length != 0)
        {
            foreach(Collider2D o in objects)
            {
                base.OnCollision(o.gameObject);
            }
        }

        Instantiate(this.explosionPrfb, this.transform.position, Quaternion.identity);


        
    }
}
