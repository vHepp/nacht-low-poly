using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDoor : MonoBehaviour
{
	public float distancePerSecond = 1f;
	public string targetTag = "BlockLocation";
	public GameObject[] blockLocations;
	public int locationBlocked;
	public Camera fpsCam; // player's camera
	public LayerMask TargetLayer; // Layer of BlockLocation
	public RaycastHit hit;
	public bool isBlocking = false;

	public int numOfFamiliarTypes = 2;
	public GameObject activeFamiliar;
	public int activeFamiliarIndex = 0;
	public GameObject[] familiarList;
	// Start is called before the first frame update
	void Start()
	{
		blockLocations = GameObject.FindGameObjectsWithTag(targetTag);
		familiarList = new GameObject[numOfFamiliarTypes];
		familiarList[0] = GameObject.FindGameObjectWithTag("Familiar");
		familiarList[1] = GameObject.FindGameObjectWithTag("Familiar_Block");
		//activeFamiliar = familiarList[0];
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("b"))
		{
			activeFamiliar = Instantiate(familiarList[activeFamiliarIndex], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
		}
		if (Input.GetButtonDown("Command"))
		{
			isBlocking = StartBlock();
		}
		if (isBlocking)
		{
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
		Debug.Log("Starting Block");

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
