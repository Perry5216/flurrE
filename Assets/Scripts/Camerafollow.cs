using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] private float xMin = -1;
	[SerializeField] private float xMax = 1;
	[SerializeField] private float yMin = -1;
	[SerializeField] private float yMax = 1;


	void LateUpdate()
	{
		float x = Mathf.Clamp(target.position.x,xMin,xMax);
		float y = Mathf.Clamp(target.position.y,yMin, yMax);

		transform.position = new Vector3(x, y, transform.position.z);
	}
}
