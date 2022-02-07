using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
	void Start() {
		DontDestroyOnLoad(this); // keep the event 
	}
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit(); // close the application anytime escape is pressed
        }
    }
}
