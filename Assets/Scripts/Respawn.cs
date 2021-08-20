using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public Transform respawnPosition;
    public GameObject player;

	private int Deaths = 0;

	// Use this for initialization
	void Start()
	{
		respawnPosition.position = GameObject.FindGameObjectWithTag("Spawn").transform.position;
	}

    IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Respawn")
		{
            yield return new WaitForSeconds(0.5f);
            this.transform.position = respawnPosition.position;

            Deaths++; //This can be used with the canvas 
		}
	}
	
    // Update is called once per frame
	void Update ()
	{
		
	}
}
