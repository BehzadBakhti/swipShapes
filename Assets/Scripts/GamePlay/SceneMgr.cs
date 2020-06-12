using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMgr : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    public int coins;
    public Text coinText;
    public int costToContinue;
    public int lifes;
    public ParticleSystem successEffect;
    public BGController thisBgController;

    public int difficulty = 1;

    public Button continueBtn;
    public Text lifesText;
    public GameObject jokker;
    public timerMgr myTimeMgr;
    public Image contPanel, coinsFly;
    public Image quitPanel;
    public bool shapeExist = false;
    public bool isGameOver = false;
    public bool isHintOn = false;
    [HideInInspector]
    public Vector3[] corners;
    public ModeChanger myModeChanger;
    public Spawner mySpawner;
    public coinManager myCoinManager;
    public CatchersMgr myCatcherManager;
    public int pointCounts;
    public int coinsToSpawn;
    [HideInInspector]
    public string gameMode;
    public bool isDynamic = false;
    public bool wrongHit = false;
    // Use this for initialization
    void Start()
    {
        thisBgController.pickRandomSprite();
        InitCorners();
        //PlayerPrefs.SetInt("keyy", 134);
        quitPanel.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        contPanel.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        coins = PlayerPrefs.GetInt(GamePrefs.userCoins);
        coinText.text = PlayerPrefs.GetInt(GamePrefs.userCoins).ToString();

        lifes = GameManager.instance.evaluteLifes();
        lifesText.text = lifes.ToString();


    }


    void Update()
    {

        if (myModeChanger.isGameStarted)
        {
            if ((!shapeExist && !isGameOver) && !isHintOn)
            {

                if (isDynamic || myCatcherManager.isCatcherActive == false)
                {
                    myCatcherManager.RestartCatchers();
                }

                mySpawner.GenerateShape(gameMode);
                myCoinManager.SpawnCoins(coinsToSpawn);
                myModeChanger.moveCount--;

            }
        }


        if (myTimeMgr.timerBar.fillAmount <= 0.02f)
        {
            GameOver();

        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopGame();
        }
    }
    public void CheckForModeChange()
    {
        if (myModeChanger.moveCount < 1)
        {
            StartCoroutine(myModeChanger.ChangeTheMode());
        }
    }

    public void GameOver()
    {

        myTimeMgr.stopTimer();
        //jokker.SetActive(true);
        if (coins < costToContinue)
        {
            continueBtn.interactable = false;
        }
        else
        {
            continueBtn.interactable = true;
        }
        contPanel.GetComponent<Animator>().SetBool("GameOver", true);

    }


    public void SetHighScore()
    {
        int lastHighScore = PlayerPrefs.GetInt(GamePrefs.highScore);
        if (score > lastHighScore)
        {

            PlayerPrefs.SetInt(GamePrefs.highScore, score);

            //########### animate New High Score ##############
        }
    }


    public void GameOverConfirm()
    {
        GameManager.instance.myAudioMgr.clickSound();
        isGameOver = true;

        lifes--;
        lifesText.text = lifes.ToString();
        PlayerPrefs.SetInt(GamePrefs.userLifes, lifes);

        SetHighScore();
        SceneManager.LoadScene("MainMenu");
    }


    public void GameOverContinue()
    {
        GameManager.instance.myAudioMgr.clickSound();
        wrongHit = false;
        coins -= costToContinue;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt(GamePrefs.userCoins, coins);
        myCoinManager.DestroyCoins();
        myTimeMgr.initTimer();
        shapeExist = false;
        contPanel.GetComponent<Animator>().SetBool("GameOver", false);
        coinsFly.GetComponent<Animator>().SetTrigger("flyCoins");



    }

    public void QuitGame()
    {
        GameManager.instance.myAudioMgr.clickSound();
        isGameOver = true;
        lifes--;
        PlayerPrefs.SetInt(GamePrefs.userLifes, lifes);
        SetHighScore();
        SceneManager.LoadScene("MainMenu");
    }

    public void StopGame()
    {
        GameManager.instance.myAudioMgr.clickSound();
        quitPanel.GetComponent<Animator>().SetBool("GameOver", true);
        myTimeMgr.stopTimer();

    }
    public void ResumeGame()
    {
        GameManager.instance.myAudioMgr.clickSound();
        myTimeMgr.initTimer();
        quitPanel.GetComponent<Animator>().SetBool("GameOver", false);

    }

    public void InitCorners()
    {
        float dx = 130f, dy = 200f;

        corners = new Vector3[4];
        corners[0] = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - dx, Screen.height - dy, 0));
        corners[0].z = 0;

        corners[1] = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - dx, dy - 50, 0));
        corners[1].z = 0;

        corners[2] = Camera.main.ScreenToWorldPoint(new Vector3(dx, Screen.height - dy, 0));
        corners[2].z = 0;

        corners[3] = Camera.main.ScreenToWorldPoint(new Vector3(dx, dy - 50, 0));
        corners[3].z = 0;



    }

}



