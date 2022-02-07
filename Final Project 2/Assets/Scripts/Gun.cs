using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

	//damage, firerate, reload speed, and ammo stats for desired gun
	public int damage = 10;
	public float range = 100f;
	public float fireRate = 15f;
	float nextTimeToFire = 0f;
	public float reloadTime = 1f;
	public bool AutoFire = false;
	public int maxAmmo, magSize;

	bool isReloading = false; // used for reloading animation
	public Animator animator; // player's animator
	public Countable ammoCountable; // ammo for current gun
	public Camera fpsCam; // the player's camera
	public ParticleSystem muzzleFlash;
	public GameObject impactEffect;
 	public LayerMask Ignore; // ignore this layer during ray casting
	public Countable pointCountable; // for score/points

	void Start() 
	{
		// set default ammo amounts, full clip and reserve
		ammoCountable.setMax(maxAmmo);
		ammoCountable.setMaxReverve(maxAmmo - magSize);
		ammoCountable.setMaxCounter(magSize);
		ammoCountable.maxOut();
	}

    // Update is called once per frame
    void Update()
    {
		// no input allowed if in the middle of reloading
		if (isReloading){
			return;
		}

		// semi auto fire
        if (Input.GetButtonDown("Fire1") && !AutoFire && Time.time >= nextTimeToFire && ammoCountable.getCount() > 0) 
		{
			nextTimeToFire = Time.time + 1f/fireRate;
			Shoot();
		}
		// full auto fire
		if (Input.GetButton("Fire1") && AutoFire && Time.time >= nextTimeToFire && ammoCountable.getCount() > 0) 
		{
			nextTimeToFire = Time.time + 1f/fireRate;
			Shoot();
		}
		// reload
		if (Input.GetKeyDown("r") && ammoCountable.getReserve() > 0 && ammoCountable.getCount() < magSize) 
		{
			StartCoroutine(Reload()); // Coroutine
		}
    }

	void Shoot() {
		ammoCountable.decrementCounter();
		// plays particle effect
		muzzleFlash.Play();

		// raycast from camera in the the center of the screen, up to the gun's range
		RaycastHit hit;
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, ~Ignore)) 
		{	
			Target target = hit.transform.GetComponent<Target>();

			if (target != null) 
			{
				pointCountable.addCounter(10); // 10 points for hitting an enemy

				//double damage on a headshot
				if (hit.collider.CompareTag("Head")) {
					target.TakeDamage(damage*2);

					if (target.health <= 0) {
						pointCountable.addCounter(100); // 100 points for a headshot kill
					}
				}
				else{
					target.TakeDamage(damage);
					
					if (target.health <= 0) {
						pointCountable.addCounter(60); // 60 points for a non-headshot kill
					}
				}
			}

			// should create a impactEffect for the bullet, but stopped working for some reason
			GameObject g = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

			// destroys the impactEffect after .2 secconds
			Destroy(g,.2f);
		}
	}

	IEnumerator Reload() 
	{
		isReloading = true;

		animator.SetBool("Reloading", true);
		yield return new WaitForSeconds(reloadTime); // Coroutine
		
		// if ammo is available and the currentMag is not full
		if (ammoCountable.getReserve() > 0 && ammoCountable.getCount() < magSize) {
			int newMagCapacity = 0, needed;
			
			needed = magSize - ammoCountable.getCount();

			// enough ammo to fill mag
			if (needed <= ammoCountable.getReserve()) {
				ammoCountable.subtractReverve(needed);
				newMagCapacity = magSize;
			} 
			// not enought ammo to fill mag
			else if (needed > ammoCountable.getReserve()) {
				newMagCapacity = ammoCountable.getCount() + ammoCountable.getReserve();
				ammoCountable.setReverve(0);
			}

			ammoCountable.setCounter(newMagCapacity);
		}
		animator.SetBool("Reloading", false);
		isReloading = false;
	}

	// resets a gun to a non-reloading state if switched mid-reload
	void OnEnable() {
		isReloading = false;
		animator.SetBool("Reloading", false);	
	}

}
