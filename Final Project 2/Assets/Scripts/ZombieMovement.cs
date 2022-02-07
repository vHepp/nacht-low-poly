using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{

	public GameObject goalObject; // target object
	public string targetTag = "Player"; // target tag of object
	NavMeshAgent agent; // navmesh agent
	public Countable playerHealthCountable; // health countable of player
	public Countable roundCountable; // track current round for difficulty (i.e. speed changes)
	public Animator myAnimator; // zombie animator
	public float attackDelay = 2f; // attack delay per zombie
	public float timeToNextAttack = 0f;


    // Start is called before the first frame update
    void Start()
    {
		agent = GetComponent<NavMeshAgent>();

		// movement speed based off current round
		if (roundCountable.getCount() > 5 && roundCountable.getCount() <= 10){
			agent.speed = Random.Range(2, 4);
		}
		if (roundCountable.getCount() > 10 && roundCountable.getCount() <= 15){
			agent.speed = Random.Range(3, 5);
		}
		if (roundCountable.getCount() > 15 && roundCountable.getCount() <= 20){
			agent.speed = Random.Range(4, 6);
		}
		if (roundCountable.getCount() > 20){
			agent.speed = 6;
		}

		// match animation speed with movement, try to prevent "skating"
		myAnimator.speed = agent.speed;
	}

	void Update()
	{
		// search for target object via tag
		goalObject = GameObject.FindGameObjectWithTag(targetTag);

		// if target if found, track it in real time
		if (goalObject != null) {
			agent.destination = goalObject.transform.position;
			PlayerHealth playerHealth = goalObject.gameObject.GetComponent<PlayerHealth>(); // needed to deal damage to player

			// distance zombie is from player
			float dist = Vector3.Distance(agent.transform.position, goalObject.transform.position);

			// if zombie is really close, damage the player (workaround for weird collider issues)
			if (Time.time >= timeToNextAttack && dist <= 2.5f) {
				timeToNextAttack = Time.time + attackDelay;
				playerHealth.dealDamage();
			}
		}
	}
}
