using UnityEngine;
using UnityEngine.UI;


public class PrintZInfo : MonoBehaviour
{
	public Countable zombieCountable;
	Text myText;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		myText.text = "Max this round: " + zombieCountable.getMax() +
					"\nLeft to spawn: " + zombieCountable.getReserve() +
					"\nCurrently spawned: " + zombieCountable.getCount() +
					"\nHealth: " + zombieCountable.getHealth();
    }
}
