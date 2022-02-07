using UnityEngine;

public class WeaponSwaper : MonoBehaviour
{
	public int weapon1 = 0, weapon2 = 1; // indexes of the 2 weapons on the player
	public int selectedWeapon = 0; // tracks which one is in hand
	public Camera fpsCam; // player's camera
	public LayerMask TargetLayer; // Layer of WallBuy Weapons
	public Countable pointCountable; // tracks player points
	public PrintCost costText; // text for price of WallBuy Weapon/Ammo refill

    // Start is called before the first frame update
    void Start()
    {
        SelectedWeapon(); // activates selected weapon, deactivates all others
    }

    // Update is called once per frame
    void Update()
    {
		// raycast for cost info of wallbuy weapoons
		RaycastHit hit;
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 1f, TargetLayer)) {
			WallBuy target = hit.transform.GetComponent<WallBuy>();
			
			costText.gunCost = target.gunCost; 
			costText.ammoCost = target.ammoCost;
		}
		else {
			costText.gunCost = 0;
			costText.ammoCost = 0;
		}

		int previousSelectedWeapon = selectedWeapon; // track if seleceted weapon changed

		// change weapons w/ scroll wheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
			if (selectedWeapon == weapon1)
				selectedWeapon = weapon2;
			else
				selectedWeapon = weapon1;
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
			if (selectedWeapon == weapon1)
				selectedWeapon = weapon2;
			else
				selectedWeapon = weapon1;
		}
		if (previousSelectedWeapon != selectedWeapon) {
			SelectedWeapon();
		}
		// Use f to buy WallBuy Weapon/Ammo
		if (Input.GetButtonDown("Interact")) {
			UseWallBuy();
		}
    }

	// activates selected weapon, deactivates all others
	void SelectedWeapon() 
	{
		int i = 0;
		foreach (Transform weapon in transform) {
			
			if (i == selectedWeapon)
				weapon.gameObject.SetActive(true);
			else
				weapon.gameObject.SetActive(false);
			i++;
		}
	}

	// get index of current weapon
	public int getWeapon() {
		return selectedWeapon;
	}
	
	// Use WallBuy weapons to purchase guns and
	void UseWallBuy() {
		RaycastHit hit;
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 1f, TargetLayer)) 
		{	
			WallBuy target = hit.transform.GetComponent<WallBuy>();
			Countable ammoCountable = target.ammoCountable;
			
			if (target != null) {
				if (target.gunNumber == weapon1 && !ammoCountable.isMaxed() && pointCountable.getCount() >= target.ammoCost) { // buy ammo for first weapon
					Debug.Log(target.ammoCost);
					selectedWeapon = weapon1;
					pointCountable.subtractCounter(target.ammoCost);
					target.BuyAmmo();
				}
				else if (target.gunNumber == weapon2 && !ammoCountable.isMaxed() && pointCountable.getCount() >= target.ammoCost) { // buy ammo for second weapon
					Debug.Log(target.ammoCost);
					selectedWeapon = weapon2;
					pointCountable.subtractCounter(target.ammoCost);
					target.BuyAmmo();
				}
				else if (target.gunNumber != weapon1 && target.gunNumber != weapon2  && pointCountable.getCount() >= target.gunCost) { // buy new gun
					if (selectedWeapon == weapon1) {  // replace weapon1 with new gun
						weapon1 = target.gunNumber;
						selectedWeapon = target.gunNumber;
						pointCountable.subtractCounter(target.gunCost);
						target.BuyAmmo();
					}
					else if (selectedWeapon == weapon2) { // replace weapon2 with new gun
						weapon2 = target.gunNumber;
						selectedWeapon = target.gunNumber;
						pointCountable.subtractCounter(target.gunCost);
						target.BuyAmmo();
					}
				}
				
				// activate new weapon and disable old one
				SelectedWeapon();
			}
		}
	}
}
