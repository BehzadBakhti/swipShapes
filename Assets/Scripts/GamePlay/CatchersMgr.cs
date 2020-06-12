using UnityEngine;

public class CatchersMgr : MonoBehaviour
{

    public SceneMgr thisSceneMgr;
    public int randColor, randShape;
    public Catcher[] myCatchersScripts;
    public GameObject[] myCatchers;
    public Color[] myColors;
    public GameObject[] catchers;
    public Color[] catcherColors;
    public bool isCatcherActive = false;

    // Use this for initialization
    void Start()
    {

        myCatchers = new GameObject[thisSceneMgr.pointCounts];
        myColors = new Color[thisSceneMgr.pointCounts];
        myCatchersScripts = new Catcher[thisSceneMgr.pointCounts];
        //RestartCatchers();

    }

    public void RestartCatchers()
    {

        if (myCatchers[0] != null)
            clearCatchers();
        isCatcherActive = true;
        if (thisSceneMgr.difficulty < 2)
        {

            reshuffle(catchers);
            reshuffle(catcherColors);
            for (int i = 0; i < thisSceneMgr.pointCounts; i++)
            {
                myCatchers[i] = (GameObject)Instantiate(catchers[i], thisSceneMgr.corners[i], Quaternion.identity);
                myCatchersScripts[i] = myCatchers[i].GetComponent<Catcher>();
                myColors[i] = catcherColors[i];
                myCatchersScripts[i].thisSprite.color = myColors[i];
                myCatchersScripts[i].catcherColor = myColors[i];
            }

        }
        else
        {

            reshuffle(catchers);
            reshuffle(catcherColors);
            if (thisSceneMgr.gameMode == "colors")
            {
                //	Debug.Log("------ COLORS -------------");
                for (int i = 0; i < thisSceneMgr.pointCounts; i++)
                {
                    randShape = UnityEngine.Random.Range(0, catchers.Length);
                    //	Debug.Log(randShape);
                    myCatchers[i] = (GameObject)Instantiate(catchers[randShape], thisSceneMgr.corners[i], Quaternion.identity);
                    myCatchersScripts[i] = myCatchers[i].GetComponent<Catcher>();
                    myColors[i] = catcherColors[i];
                    myCatchersScripts[i].thisSprite.color = myColors[i];
                    myCatchersScripts[i].catcherColor = myColors[i];

                }
                //	Debug.Log("-------------------");

            }
            else if (thisSceneMgr.gameMode == "shapes")
            {
                //		Debug.Log("------ SHAPES -------------");

                for (int i = 0; i < thisSceneMgr.pointCounts; i++)
                {
                    randColor = UnityEngine.Random.Range(0, catcherColors.Length);
                    //Debug.Log(randColor);
                    myCatchers[i] = (GameObject)Instantiate(catchers[i], thisSceneMgr.corners[i], Quaternion.identity);
                    myCatchersScripts[i] = myCatchers[i].GetComponent<Catcher>();
                    myColors[i] = catcherColors[randColor];
                    myCatchersScripts[i].thisSprite.color = myColors[i];
                    myCatchersScripts[i].catcherColor = myColors[i];

                }
                //		Debug.Log("-------------------");
            }
            else if (thisSceneMgr.gameMode == "both")
            {
                int[,] tracker = new int[thisSceneMgr.pointCounts, 2];


                for (int i = 0; i < thisSceneMgr.pointCounts; i++)
                {
                    randColor = UnityEngine.Random.Range(0, catcherColors.Length);// out of 7
                    randShape = UnityEngine.Random.Range(0, catchers.Length);// out of 8

                    tracker[i, 0] = randColor;
                    tracker[i, 1] = randShape;


                    for (int j = 0; j < i; j++)
                    {
                        if (tracker[j, 0] == tracker[i, 0] && tracker[j, 1] == tracker[i, 1])
                        {
                            i--;
                            break;
                        }
                    }


                }

                for (int i = 0; i < thisSceneMgr.pointCounts; i++)
                {
                    myCatchers[i] = (GameObject)Instantiate(catchers[tracker[i, 1]], thisSceneMgr.corners[i], Quaternion.identity);
                    myCatchersScripts[i] = myCatchers[i].GetComponent<Catcher>();
                    myColors[i] = catcherColors[tracker[i, 0]];
                    myCatchersScripts[i].thisSprite.color = myColors[i];
                    myCatchersScripts[i].catcherColor = myColors[i];

                }


            }


        }


    }


    public void clearCatchers()
    {
        for (int i = 0; i < myCatchers.Length; i++)
        {

            Destroy(myCatchers[i].gameObject);
        }
        isCatcherActive = false;

    }


    ///////////////////////////////
    ////////// UTILITY FUNCTIONS ////////
    ///////////////////////////////


    void reshuffle(GameObject[] objs)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < objs.Length; t++)
        {
            GameObject tmp = objs[t];
            int r = Random.Range(t, objs.Length);
            objs[t] = objs[r];
            objs[r] = tmp;
        }
    }

    void reshuffle(Color[] objs)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < objs.Length; t++)
        {
            Color tmp = objs[t];
            int r = Random.Range(t, objs.Length);
            objs[t] = objs[r];
            objs[r] = tmp;
        }
    }


}
