using UnityEngine;

public class Hover : MonoBehaviour
{
	public float current = 0f;
	public Transform old;
	public float rate = .2f;
	public float radius = .005f;
	public float newY;
	public Vector3 newPosition;

	public bool shouldHover = true;

	void Start()
	{
	}
	// Update is called once per frame
	void Update()
	{
		if (shouldHover)
		{
			old = GetComponent<Transform>();
			current += Time.deltaTime;
			newY = old.position.y + Mathf.Sin(current + rate) * radius;
			newPosition = new Vector3(old.position.x, newY, old.position.z);
			transform.position = newPosition;
		}
	}
}
