using UnityEngine;

public class Progression : MonoBehaviour
{

	public Countable zombieCountable;
	public Countable roundCountable;
	public Countable pointCountable;
    // Start is called before the first frame update
    void Start()
    {
		// set starting values
		roundCountable.setCounter(0);
		zombieCountable.setMax(0);
		zombieCountable.setReverve(0);
		zombieCountable.setHealth(150);
		pointCountable.setCounter(500);
    }

    // Update is called once per frame
    void Update()
    {
		// keep track of zombies on the map, change round when all are spawned AND dead
		zombieCountable.setCounter(GameObject.FindGameObjectsWithTag("Zombie").Length);
		if (zombieCountable.getCount() <= 0 && zombieCountable.getReserve() <= 0) {
			roundCountable.incrementCounter();
			setRound();
		}
    }

	// calculates health and number of zombies per round
	void setRound() {
		if (roundCountable.getCount() < 10) {
			switch (roundCountable.getCount())
			{
				case 1:
					zombieCountable.setMax(6);
					zombieCountable.setHealth(150);
					break;
				case 2:
					zombieCountable.setMax(8);
					zombieCountable.setHealth(250);
					break;
				case 3:
					zombieCountable.setMax(13);
					zombieCountable.setHealth(350);
					break;
				case 4:
					zombieCountable.setMax(18);
					zombieCountable.setHealth(450);
					break;
				case 5:
					zombieCountable.setMax(24);
					zombieCountable.setHealth(550);
					break;
				case 6:
					zombieCountable.setMax(27);
					zombieCountable.setHealth(650);
					break;
				case 7:
					zombieCountable.setMax(28);
					zombieCountable.setHealth(750);
					break;
				case 8:
					zombieCountable.setMax(28);
					zombieCountable.setHealth(850);
					break;
				case 9:
					zombieCountable.setMax(29);
					zombieCountable.setHealth(950);
					break;
			}
			zombieCountable.setReverve(zombieCountable.getMax());
		}

		else if (roundCountable.getCount() >= 10) {
			// formula for # of zombies and health @ round 10 or higher
			zombieCountable.setHealth((int)(zombieCountable.getHealth() * 1.1));
			zombieCountable.setMax((int)(.0842 * Mathf.Pow(roundCountable.getCount(),2) + .1954 * roundCountable.getCount() + 22.05));
			zombieCountable.setReverve(zombieCountable.getMax());
		}
	}
}
