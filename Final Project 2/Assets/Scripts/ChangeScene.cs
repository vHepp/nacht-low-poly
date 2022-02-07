using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneNumber; // desired scene number to swtich to
    // Update is called once per frame
	
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
