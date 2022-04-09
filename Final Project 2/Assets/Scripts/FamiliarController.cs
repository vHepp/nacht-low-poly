using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamiliarController : MonoBehaviour
{
	//Controller Stuff
	public int numOfFamiliarTypes = 2;
	public GameObject[] familiarList;
	public int activeFamiliar;

	// Movement Stuff
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

	//Block Stuff
	public GameObject[] blockLocations;
	public int locationBlocked;
	public Camera fpsCam; // player's camera
	public LayerMask TargetLayer; // Layer of BlockLocation
	public RaycastHit hit;
	public bool isBlocking = false;


	// Start is called before the first frame update
	void Start()
	{
		// Controller stuff
		familiarList = new GameObject[numOfFamiliarTypes];
		familiarList[0] = GameObject.FindGameObjectWithTag("Familiar");
		familiarList[1] = GameObject.FindGameObjectWithTag("Familiar_Block");
		familiarList[0].SetActive(true);
		familiarList[1].SetActive(false);
		activeFamiliar = 0;
		
		// Block stuff
		blockLocations = GameObject.FindGameObjectsWithTag("BlockLocation");

	}

	// Update is called once per frame
	void Update()
	{
		current += Time.deltaTime;

		// "Command" = "v"
		if(Input.GetButtonDown("Command")){
			if(activeFamiliar == 0){
				//switch to blocking
				familiarList[1].SetActive(true);
				familiarList[0].SetActive(false);
				activeFamiliar = 1;
				distanceFromPlayer = 1f;

				isBlocking = StartBlock(); 
			}
			else
			{
				//switch to following
				familiarList[0].SetActive(true);
				familiarList[1].SetActive(false);
				activeFamiliar = 0;
				distanceFromPlayer = 2.5f;
			}
		}

		if(activeFamiliar == 0){
			// Follow
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
		else if(activeFamiliar == 1 && isBlocking){
			Transform t = hit.transform;
			transform.position = Vector3.MoveTowards(transform.position, t.position, distancePerSecond * Time.deltaTime);
			if (transform.position.x == t.position.x && Mathf.Abs(transform.position.y - t.position.y) < .1 && transform.position.z == t.position.z)
			{
				transform.position = t.position;
				transform.rotation = t.rotation;
				isBlocking = false;
			}
		}	
	}

	bool StartBlock()
	{
		// raycast for placeable 
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 10f, TargetLayer))
		{
			Debug.Log("Hit something!");
			if (hit.collider.isTrigger)
			{
				Debug.Log("Hit the trigger!");
				return true;
			}
			else
			{
				Debug.Log("Not a trigger!");
			}
		}
		return false;

	}

}
