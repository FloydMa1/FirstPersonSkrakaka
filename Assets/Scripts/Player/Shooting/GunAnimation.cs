using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimation : MonoBehaviour
{
	private float leftToRotate = 0;
	private float rotatePerSecond;
	
	public void Shoot(float timeToRotates)
	{
		leftToRotate += 360;
		rotatePerSecond = 360 / timeToRotates;
	}

	private void Update()
	{
		if (leftToRotate > 0)
		{
			transform.Rotate(-rotatePerSecond * Time.deltaTime, 0, 0, Space.Self);
			leftToRotate -= rotatePerSecond * Time.deltaTime;
		}
		else
		{
			var rot = transform.localEulerAngles;
			rot.x = 0;
			transform.localEulerAngles = rot;
		}
	}
}
