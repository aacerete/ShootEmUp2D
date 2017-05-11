using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDettect : MonoBehaviour {
        EnemyMove enemyMove;
    
	// Use this for initialization
	void Start () {
        this.enemyMove = this.transform.parent.GetComponent<EnemyMove>();
	}
	
	
	void OnTriggerEnter2D (Collider2D player) {
        
        this.enemyMove.IsPlayerNear(true);
	}

    void OnTriggerExit2D(Collider2D player)
    {
       
        this.enemyMove.IsPlayerNear(false);
    }
}
