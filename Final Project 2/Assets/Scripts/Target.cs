using UnityEngine;

public class Target : MonoBehaviour
{
	public int health = 150;
	public Countable healthCountable;
	void Start() {
		health = healthCountable.getHealth();
	}

	public void TakeDamage (int amount) {
		health -= amount;
		if (health <= 0f)
		{
			Die();
		}
	}

	void Die () {
		Destroy(gameObject);
	}
}
