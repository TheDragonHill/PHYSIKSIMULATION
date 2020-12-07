using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
	public float impulsForce = 1500f;
	public float impulsRadius = 4f;
	public float impulsUpward = 0.4f;

	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			impuls();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Asteroid")
		{
			//End Game
			Debug.Log("GameOver");
			Application.Quit();
		}
	}

	public void impuls()
	{
		//get impuls position
		Vector3 impulsPos = transform.position;
		//get colliders in that position and radius
		Collider[] colliders = Physics.OverlapSphere(impulsPos, impulsRadius);
		//add impuls force to all colliders in that overlap sphere
		foreach (Collider hit in colliders)
		{
			//get rigidbody from collider object
			Rigidbody rb = hit.GetComponent<Rigidbody>();
			if (rb != null)
			{
				//add impuls force to this body with given parameters
				rb.AddExplosionForce(impulsForce, transform.position, impulsRadius, impulsUpward);
			}
		}
	}

}
