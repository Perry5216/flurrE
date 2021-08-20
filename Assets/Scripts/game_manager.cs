using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour {
	public static int deaths;
	float time;
	public GameObject Spawnpoint;

	// Use this for initialization
	void Start () 
	{
		deaths = 0;
		time = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		time = Time.timeSinceLevelLoad;
		
	}
}
