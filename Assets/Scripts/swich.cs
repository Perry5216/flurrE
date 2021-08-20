using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swich : MonoBehaviour
{
    public GameObject[] itangled_objecks;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(GameObject g in itangled_objecks)
        {
            g.GetComponent<trigered_objected>().tirggered = true; 
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        foreach (GameObject g in itangled_objecks)
        {
            g.GetComponent<trigered_objected>().tirggered = false;
        }
    }

}
