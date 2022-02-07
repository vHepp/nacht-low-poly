using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ChangeAfterVideo : MonoBehaviour
{
	VideoPlayer video; // the video player with my cutscene attached
 
    void Awake() // play the cutscene when the game starts
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver; // check to see if the cutscene is over 
		         
    }
 
     void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(1); // loads the game scene after the cutscene
    }
}
