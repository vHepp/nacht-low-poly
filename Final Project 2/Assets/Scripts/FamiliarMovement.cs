using UnityEngine;

public class FamiliarMovement : MonoBehaviour
{
	public GameObject player;
	public float distanceFromPlayer;
	public float distancePerSecond = 1f;
	public float innerRadius = 2.5f;
	public float outerRadius = 4.5f;
	public float current = 0f;
	public float nextTimeout;
	public float mTimeoutDuration = .2f;
	public float iTimeoutDuration = .2f;
	public int moveState = 0;


	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		current += Time.deltaTime;

		// follow player
		distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
		if (distanceFromPlayer > outerRadius)
		{
			if (moveState == 0 && current >= nextTimeout)
			{
				transform.position = Vector3.MoveTowards(transform.position, player.transform.position, distancePerSecond * Time.deltaTime);
			}
			else if (moveState == 1 && current >= nextTimeout)
			{
				moveState = 0; // fix state error
			}
			else if (moveState == 2)
			{
				nextTimeout = current + iTimeoutDuration;
				moveState = 0;
			}
		}
		else if (distanceFromPlayer <= outerRadius && distanceFromPlayer >= innerRadius)
		{
			if (moveState == 0)
			{
				nextTimeout = current + mTimeoutDuration;
				moveState = 1;
			}
			if (moveState == 1)
			{
				if (current >= nextTimeout)
				{
					moveState = 2;
				}
				else
				{
					transform.position = Vector3.MoveTowards(transform.position, player.transform.position, distancePerSecond * Time.deltaTime);
				}
			}
		}
		else if (distanceFromPlayer < innerRadius)
		{
			moveState = 2;
		}
	}

}
