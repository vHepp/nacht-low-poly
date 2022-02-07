using UnityEngine;

public class Turn : MonoBehaviour
{
	public float rotationRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Rotate(new Vector3(0,-rotationRate,0));
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Rotate(new Vector3(0,rotationRate,0));
		}
    }
}
