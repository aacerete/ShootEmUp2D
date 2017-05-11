using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public bool androidInput;
    private int speed;
    private Vector3 input;
    private Rigidbody2D rigbody;
    private Camera playerCamera;


	// Use this for initialization
	void Start () {
        this.speed = 10;
        this.rigbody = GetComponent<Rigidbody2D>();
        this.input = Vector3.zero;

        this.playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        this.input.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        if (this.androidInput)
        {
            if (this.input != Vector3.zero)
            {
                if (this.input.y != 0)
                {
                    if (this.input.y > 0)
                    {
                        this.transform.rotation = Quaternion.identity;
                    }
                    else if (this.input.y < 0)
                    {
                        this.transform.rotation = Quaternion.Euler(0, 0, 180);
                    }
                }
                else if (this.input.x != 0)
                {
                    if (this.input.x > 0)
                    {
                        this.transform.rotation = Quaternion.Euler(0, 0, 270);
                    }
                    else if (this.input.x < 0)
                    {
                        this.transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                }

            }
        }
        else
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = (Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg) + 270;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        
	}

    private void FixedUpdate()
    {
        this.rigbody.velocity = this.input * this.speed;
    }
}
