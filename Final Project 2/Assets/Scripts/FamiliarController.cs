using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamiliarController : MonoBehaviour
{
	//Controller Stuff
	public int numOfFamiliarTypes = 2;
	public GameObject[] familiarList;
	public int activeFamiliar;

/* 	// Movement Stuff
	public GameObject player;
	public float distanceFromPlayer;
	public float distancePerSecond = 1f;
	public float innerRadius = 2.5f;
	public float outerRadius = 4.5f;
	public float current = 0f;
	public float nextTimeout;
	public float mTimeoutDuration = .2f;
	public float iTimeoutDuration = .2f;
	public int moveState = 0; */


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
	}

	// Update is called once per frame
	void Update()
	{
		//current += Time.deltaTime;

		// "Command" = "v"
		if(Input.GetButtonDown("Command")){
			if(activeFamiliar == 0){
				familiarList[1].SetActive(true);
				familiarList[0].SetActive(false);
				activeFamiliar = 1;
			}
			else
			{
				familiarList[0].SetActive(true);
				familiarList[1].SetActive(false);
				activeFamiliar = 0;
			}
		}
	}
}
