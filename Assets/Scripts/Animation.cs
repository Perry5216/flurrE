using UnityEngine;
using System.Collections;

public class Animation : MonoBehaviour
{

	static Animator anim;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		float translation = Mathf.Abs(Input.GetAxis("Horizontal")); //the Abs or absolute function is part of Unity's Mathf (floating point maths) library, so we call it via a call to that library.

		anim.SetFloat("translation", translation); // Presuming the parameter you are using for the condition in the animator is called "translation".

		if (Input.GetButtonDown("Jump"))
		{
			anim.SetTrigger("isJumping");
		}

		if (translation != 0)
		{
			anim.SetBool("isRunning", true);
			anim.SetBool("isIdle", false);
		}
		else
		{
			anim.SetBool("isRunning", false);
			anim.SetBool("isIdle", true);
		}

	}
}