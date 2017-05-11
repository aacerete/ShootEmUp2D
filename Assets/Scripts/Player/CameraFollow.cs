using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private float timeScale = 4;
    private Transform player;
    private float zOffset;
    private Vector3 targetPosition;

    private void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        zOffset = 10;
    }

    void Update()
    {
        if (this.player != null)
        {
            this.targetPosition = this.player.position + Vector3.back * this.zOffset;

            this.transform.position = Vector3.Lerp(this.transform.position, this.targetPosition, Time.deltaTime * this.timeScale);
        }
    }
}