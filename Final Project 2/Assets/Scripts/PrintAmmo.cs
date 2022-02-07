using UnityEngine;
using UnityEngine.UI;

public class PrintAmmo : MonoBehaviour
{
	public Countable selectedAmmoCountable; // countable for specific gun
	public GameObject WeaponHolder; // Holder for all guns
	public int selectedGun; // index of slected gun
	public WeaponSwaper weaponSwaper;
	public Countable[] countables; // countables for all guns
	Text myText; // for ammo output
    // Start is called before the first frame update
    void Start()
    {
		weaponSwaper = WeaponHolder.GetComponent<WeaponSwaper>();
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		selectedGun = weaponSwaper.getWeapon(); // runs the getWeapon function to retrieve index of the selected gun's countable

		// switch which countable PrintAmmo uses
		switch (selectedGun)
		{
			case 0:
				selectedAmmoCountable = countables[0];
				break;
			case 1:
				selectedAmmoCountable = countables[1];
				break;
			case 2:
				selectedAmmoCountable = countables[2];
				break;
			case 3:
				selectedAmmoCountable = countables[3];
				break;
			case 4:
				selectedAmmoCountable = countables[4];
				break;
			case 5:
				selectedAmmoCountable = countables[5];
				break;
			default:
				Debug.Log("ERROR WITH SWITCH IN PRINTAMMO");
				break;
		}
		myText.text = selectedAmmoCountable.getCount() + " / " + selectedAmmoCountable.getReserve();
    }
}
