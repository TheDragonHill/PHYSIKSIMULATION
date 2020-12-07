using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
	//Restricted the World
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject)
		{
			Destroy(other.gameObject);
		}
	}
}
