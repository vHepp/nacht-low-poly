using UnityEngine;
using UnityEngine.UI;

public class PrintCost : MonoBehaviour
{
    // Start is called before the first frame update
    Text myText;
	public int gunCost, ammoCost;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		if (gunCost != 0)
			myText.text = "Gun Cost: " + gunCost + "     Ammo Cost: " + ammoCost;
		else
			myText.text = "";
    }
}
