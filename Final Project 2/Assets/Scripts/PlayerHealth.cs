using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
	public Countable playerHealthCountable;
	public string tagName = "Hand"; // tag for zombie hand that does dama
	public float healDelay = 4f;
	public float timeToNextHeal = 0f;
	public bool needHeal;
    void Start()
    {
		// set starting health to full, doesn't need healed
        playerHealthCountable.setHealth(5);
		needHeal = false;
    }

	void Update() 
	{
		// needs healing and the healing delay is over
		if (needHeal == true && playerHealthCountable.getHealth() < 5f && Time.time >= timeToNextHeal) {
			playerHealthCountable.setHealth(5);
			needHeal = false;
		}
	}

	//player takes damage
	public void dealDamage() {
		playerHealthCountable.decrementHealth();
		
		needHeal = true;
		timeToNextHeal = Time.time + healDelay;
	}
}
