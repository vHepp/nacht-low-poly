using UnityEngine;

public class Chase : MonoBehaviour
{
    public float distancePerSecond = 1f; // movement speed
    public string tagname = "target"; // target to chase

    // Update is called once per frame
    void Update()
    {
        // Find the object with the given tag
        GameObject target = GameObject.FindWithTag(tagname);

        // Get difference between location of the target and current location
        Vector3 delta = target.transform.position - transform.position;

        // Normalize to magnitude 1 
        delta.Normalize();

        // Normalize to time since last frame and multiply by speed
        delta *= Time.deltaTime * distancePerSecond;

        // Move by that amount
        transform.Translate(delta, Space.World);

        // Point the y-axis of this object towards its location
        transform.LookAt(new Vector3(target.transform.position.x,transform.position.y,target.transform.position.z));

    }
}
