using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour {

    public float pushForce;

	// Use this for initialization
	void Start ()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(randomPush(), randomPush()));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    float randomPush()
    {
        float min = pushForce;
        float max = pushForce;
        return Random.Range(min, max);
    }
}
