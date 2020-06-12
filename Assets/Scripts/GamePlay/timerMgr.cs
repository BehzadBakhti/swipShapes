using UnityEngine;
using UnityEngine.UI;

public class timerMgr : MonoBehaviour
{
    public Image timerBar;
    public float timeInterval;
    bool isRunning = false;
    float startTime;
    Animator timerAnim;

    // Use this for initialization
    void Start()
    {
        timerBar = this.GetComponent<Image>();
        timerAnim = this.GetComponent<Animator>();
        //initTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - startTime < timeInterval) && isRunning)
        {
            timerBar.fillAmount -= Time.deltaTime / timeInterval;

        }

        timerAnim.SetBool("timeUp", timerBar.fillAmount < 0.5f);
    }

    public void initTimer()
    {
        isRunning = true;
        startTime = Time.time;
        timerBar.fillAmount = 1f;
    }


    public void stopTimer()
    {
        isRunning = false;

    }
}
