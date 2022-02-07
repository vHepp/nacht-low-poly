using UnityEngine;
using UnityEngine.UI;

public class PrintInfo : MonoBehaviour
{
	public Countable infoCountable;
	Text myText;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		myText.text = "" + infoCountable.getCount();
    }
}
