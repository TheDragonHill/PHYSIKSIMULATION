using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject ast;
	public GameObject sat;
	bool mPressed = false;

	Vector3 mStart;
	Vector3 mEnd;

	List<GameObject> sats = new List<GameObject>();
	List<GameObject> deleteList = new List<GameObject>();

	public float maxcounter = 10;
	public float counter;

	double timer = 0;

	void Update()
    {
		//Create clones from the Satellite if you press the left Mousebutton
		if (Input.GetMouseButtonDown(0) && mPressed == false)
		{
			mPressed = true;

			Vector3 mPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mPoint.Set(mPoint.x, mPoint.y, 0);

			mStart = mPoint;
		}
		if(Input.GetMouseButtonUp(0) && counter != maxcounter)
		{
			mPressed = false;
			Vector3 mPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mPoint.Set(mPoint.x, mPoint.y, 0);


			GameObject clone = Instantiate(sat, mPoint, Quaternion.identity);
			clone.SetActive(true);

			counter++;
			Debug.Log(counter);
		}

		if (sats.Capacity != 0)
		{
			for (int i = 0; i <= sats.Count; i++)
			{
				for (int j = 0; j < sats.Count; j++)
				{
					if (i == j) break;
					if ((sats[i].transform.position - sats[j].transform.position).magnitude < sats[i].GetComponent<Satellite>().radiuz + sats[j].GetComponent<Satellite>().radiuz)
					{
						deleteList.Add(sats[i]);
						deleteList.Add(sats[j]);
					}
				}
			}
			for (int i = 0; i < deleteList.Count; i++)
			{
				sats.Remove(deleteList[i]);
				Destroy(deleteList[i]);
			}
			deleteList.Clear();
		}

		timer += 0.01;

		if (timer >= 1)
		{
			//SPAWN
			timer = 0;
			GameObject clone = Instantiate(ast, new Vector3(-10, 0 + Random.Range(5, -5), 0), Quaternion.identity);
			clone.SetActive(true);
		}
	}
}
