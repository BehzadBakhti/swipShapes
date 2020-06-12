using UnityEngine;

public class coinCollector : MonoBehaviour
{

    // Use this for initialization

    public SceneMgr thisSceneMgr;
    private AudioSource coinSound;
    void Start()
    {
        thisSceneMgr = FindObjectOfType<SceneMgr>();
        coinSound = this.gameObject.GetComponent<AudioSource>();

    }


    void OnTriggerEnter(Collider obj)
    {

        if (obj.gameObject.tag == "coin")
        {
            coinSound.Play();
            obj.gameObject.SetActive(false);
            thisSceneMgr.coins++;
            thisSceneMgr.coinText.text = thisSceneMgr.coins.ToString();
            PlayerPrefs.SetInt(GamePrefs.userCoins, thisSceneMgr.coins);
        }

    }

}
