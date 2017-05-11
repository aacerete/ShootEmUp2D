using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public static GameMaster current;

    public Slider playerHealthBar;
    public Text weaponAmmo;
    public Image weaponIcon;
    public Text winShow;


    // Use this for initialization
    void Awake () {
        current = this;
        winShow.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
        if (playerHealthBar.value <= 0)
        {
            winShow.enabled = true;
        }
	}
}
