using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public int damage = -10;
    private Rigidbody2D body;
    private Transform player;
    private bool isPlayerNear;
    private Vector3 enemyToPlayer;
    private float angle;
    private float speed;
    private bool inAttack;
    

    // Use this for initialization
	void Start () {
        this.body = this.GetComponent<Rigidbody2D>();
        this.isPlayerNear = false;
        this.inAttack = false;
        this.speed = 4;
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.isPlayerNear && !this.inAttack)
        {
        this.enemyToPlayer = this.transform.position - this.player.position;
        this.angle = (Mathf.Atan2(this.enemyToPlayer.y, this.enemyToPlayer.x) * Mathf.Rad2Deg) + 90;
        this.transform.rotation = Quaternion.Euler(0, 0, this.angle);

            
            if (Vector3.Distance(this.transform.position, this.player.position) < 3) 
            {
                StartCoroutine(Attack());
            }
                  
        }
    }

    IEnumerator Attack()
    {
        this.inAttack = true;
        Vector3 originalPos = this.transform.position;
        Vector3 targetPos = this.player.position;

        float attackSpeed = 1.5f;
        float percent = 0;
        float interpolation = 0;

        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            interpolation = (-percent * percent + percent) * 4;
            transform.position = Vector3.Lerp(originalPos, targetPos, interpolation);

            yield return null;
        }
        this.player.GetComponent<Entity>().ModifyHealth(this.damage);
        yield return new WaitForSeconds(1);

        this.inAttack = false;
    }

    private void FixedUpdate()
    {

        if (isPlayerNear && !this.inAttack)
        {
            this.body.velocity = this.transform.up * this.speed;
        }
        else
        {
            this.body.velocity = Vector3.zero;
        }   

    }

    public void IsPlayerNear(bool isNear)
    {
        this.isPlayerNear = isNear; 
    }
}
