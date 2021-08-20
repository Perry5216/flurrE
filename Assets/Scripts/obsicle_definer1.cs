using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsicle_definer1 : MonoBehaviour 
{
	public GameObject splater;
	public Transform[] targets;
	public int currentTarget;
	public float sinSpeed;
	public GameObject portal_exit;
	public bool portal_statuss;
	public bool moves;
	public bool deadly;
	public bool portal;

	// Use this for initialization
	void Start () 
	{
		currentTarget = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moves)
		{
			this.transform.Rotate(new Vector3(0, 0, sinSpeed * Time.deltaTime));
			this.transform.position = Vector3.MoveTowards(this.transform.position, targets[currentTarget].position, 0.1f);

			if (Mathf.Abs(Vector3.Distance(this.transform.position, targets[currentTarget].transform.position)) < 0.1f)
			{
				switch (currentTarget)
				{
				case 0:
					currentTarget = 1;
					break;
				case 1:
					currentTarget = 0;
					break;
				default:
					currentTarget = 1;
					break;

				}

			}
		}

	}

	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player")&& deadly)
		{
			Instantiate(splater, other.transform.position, other.transform.rotation);
		}

		if (portal) 
		{
			portal_exit.GetComponent<BoxCollider2D>().enabled = false;
			other.gameObject.transform.position = portal_exit.transform.position;
			yield return new WaitForSeconds (2.0f);
			portal_exit.GetComponent<BoxCollider2D>().enabled = true;
		}

	}

}
