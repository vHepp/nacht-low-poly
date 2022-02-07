using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
	public int sceneNumber; // desire
	public Countable playerHealthCountable; // player's health
    // Update is called once per frame
	
    void Update()
    {
		// switch scene if player "dies"
        if (playerHealthCountable.getHealth() <= 0)
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
