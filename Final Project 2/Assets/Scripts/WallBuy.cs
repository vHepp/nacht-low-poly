using UnityEngine;

public class WallBuy : MonoBehaviour
{
	// cost info for a given gun
	public int gunNumber = 0;
	public Countable ammoCountable;
	public int ammoCost, gunCost; // different cost for gun and ammo refill

	// maxes out ammo for a given gun
	public void BuyAmmo() {
		ammoCountable.maxOut();
	}
}
