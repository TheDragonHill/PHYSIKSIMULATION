using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
	Vector2 Acceleration;
	public Vector2 Velocity;

	public float Speed = 10;
	public float radiuz = 1;

	public GameObject Earth;

	public GameObject cam;

	void Start()
	{
		if (Velocity.x == 0)
		{
			Velocity = Quaternion.Euler(0, 0, 90) * (Earth.transform.position - transform.position).normalized * 10;
		}
		else
		{
			Velocity *= Speed;
		}
		Velocity = new Vector2(8, 8);
	}

	private void FixedUpdate()
	{
		Acceleration = (Earth.transform.position - transform.position).normalized * 0.981f;
		Velocity = Velocity + Acceleration;
	}

	void Update()
	{
		transform.position += (Vector3)Velocity * Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Asteroid")
		{
			//Destroy Object if it collides with a Asteroid
			Destroy(gameObject);

			cam.GetComponent<GameManager>().counter--;
			//gameManager.counter--;
		}
	}
}