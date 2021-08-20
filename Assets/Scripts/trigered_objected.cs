using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigered_objected : MonoBehaviour
{
    public bool tirggered = false;
    public GameObject target;
    public GameObject home;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (tirggered == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, 0.1f);
        }

        if (tirggered == false)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, home.transform.position, 0.1f);
        }
    }
}
