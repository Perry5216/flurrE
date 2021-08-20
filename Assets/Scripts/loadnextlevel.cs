using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadnextlevel : MonoBehaviour
{

	[SerializeField] private string loadLevel;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			SceneManager.LoadScene(loadLevel);
		}
	}
}
