using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ModeChanger : MonoBehaviour
{
    SceneMgr thisSceneMgr;
    public int moveCount;
    string[] gameModes = new string[] { "both", "colors", "shapes" };
    public Image[] modeChangePanel;
    public Sprite[] sideSprites;
    public Image sideNote;
    public int lastIndx = 0;
    public bool isGameStarted = false;


    void Start()
    {
        thisSceneMgr = FindObjectOfType<SceneMgr>();
        thisSceneMgr.myModeChanger = this;
        StartCoroutine(InitGameMode());
        thisSceneMgr.gameMode = gameModes[0];
        moveCount = Random.Range(4, 6);
        thisSceneMgr.myTimeMgr.stopTimer();
    }
    void Update()
    {

    }
    // Update is called once per frame

    public IEnumerator ChangeTheMode()
    {
        yield return new WaitForEndOfFrame();
        thisSceneMgr.difficulty++;
        //thisSceneMgr.myTimeMgr.timeInterval=4.0f/thisSceneMgr.difficulty+2.5f;
        thisSceneMgr.isHintOn = true;
        lastIndx = randIndex(lastIndx, gameModes.Length);
        modeChangePanel[lastIndx].GetComponent<Animator>().SetBool("HintAppear", true);//= new Vector3(1,1,1);
        Destroy(thisSceneMgr.mySpawner.activeShape);
        thisSceneMgr.myCatcherManager.clearCatchers();
        thisSceneMgr.myCoinManager.DestroyCoins();

        thisSceneMgr.myTimeMgr.stopTimer();
        yield return new WaitForSeconds(2.0f);
        thisSceneMgr.shapeExist = false;
        thisSceneMgr.isHintOn = false;
        //thisSceneMgr.myCatcherManager.RestartCatchers();
        thisSceneMgr.myTimeMgr.initTimer();
        modeChangePanel[lastIndx].GetComponent<Animator>().SetBool("HintAppear", false);
        sideNote.sprite = sideSprites[lastIndx];
        //modeChangePanel[lastIndx].GetComponent<RectTransform>().localScale= new Vector3(0,0,0);
        thisSceneMgr.gameMode = gameModes[lastIndx];
        moveCount = Random.Range(5, 6);

        //thisSceneMgr.mySpawner.GenerateShape(gameModes[lastIndx]);
        thisSceneMgr.myCoinManager.SpawnCoins(0);
    }


    public IEnumerator InitGameMode()
    {
        thisSceneMgr.isHintOn = true;
        //modeChangePanel[0].	modeChangePanel[lastIndx].GetComponent<Animator>().SetBool("HintAppear",true);;
        modeChangePanel[0].GetComponent<Animator>().SetBool("HintAppear", true);
        thisSceneMgr.myTimeMgr.stopTimer();
        yield return new WaitForSeconds(3.0f);
        isGameStarted = true;
        thisSceneMgr.isHintOn = false;
        thisSceneMgr.myTimeMgr.initTimer();
        //modeChangePanel[0].GetComponent<RectTransform>().localScale= new Vector3(0,0,0);
        modeChangePanel[0].GetComponent<Animator>().SetBool("HintAppear", false);
        sideNote.sprite = sideSprites[0];
        sideNote.color = new Color(1, 1, 1, 1);
        //thisSceneMgr.mySpawner.GenerateShape(gameModes[0]);
        thisSceneMgr.myCoinManager.SpawnCoins(0);
    }



    int randIndex(int lst, int max)
    {

        int i = Random.Range(0, max);
        if (i == lst)
        {
            return randIndex(lst, max);
        }
        else
        {
            return i;

        }
    }

}
