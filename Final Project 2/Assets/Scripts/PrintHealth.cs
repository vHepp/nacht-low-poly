using UnityEngine;
using UnityEngine.UI;

public class PrintHealth : MonoBehaviour
{
	Image myImage; // health bar
	public Countable healthCountable; // health countable

    // Start is called before the first frame update
    void Start()
    {
		myImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        myImage.fillAmount = (1f * healthCountable.getHealth())/5f; // health bar fill matches current health
    }
}
