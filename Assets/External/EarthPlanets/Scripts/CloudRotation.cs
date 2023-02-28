using UnityEngine;
using System.Collections;

public class CloudRotation : MonoBehaviour
{
	public float planetSpeedRotation = 3.0f;

	void Update ()
	{
		transform.Rotate(Vector3.up * Time.deltaTime * planetSpeedRotation);
	}
}
