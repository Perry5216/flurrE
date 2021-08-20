using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parrallaxing : MonoBehaviour {

    public GameObject player;
    public float offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = new Vector3(-(player.transform.position.x - Camera.main.transform.position.x)/10 + offset, (this.transform.position.y) + offset, player.transform.position.z);
	}
}