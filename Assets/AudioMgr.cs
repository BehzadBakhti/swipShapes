using UnityEngine;

public class AudioMgr : MonoBehaviour
{


    public AudioSource mainMusic, clickSnd, soundEffects;
    // Use this for initialization
    void Start()
    {
        mainMusic.Play();

    }



    public void clickSound()
    {
        clickSnd.Play();
    }
}
