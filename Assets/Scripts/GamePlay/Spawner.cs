using UnityEngine;


public class Spawner : MonoBehaviour
{

    // Use this for initialization
    public SceneMgr thisSceneMgr;
    public GameObject[] baseShapes;
    public GameObject activeShape;
    public Color[] baseColors;
    private Catcher[] catcherScripts;
    private Color[] catchersColors;


    void Start()
    {
        // lastShapeIndx=Random.Range(0,4);
        // catcherScripts=thisSceneMgr.myCatcherManager.myCatchersScripts;
        // catchersColors=thisSceneMgr.myCatcherManager.myColors;
        // lastShapeName=catcherScripts[lastShapeIndx].catcherShape;

    }

    // Update is called once per frame
    public void GenerateShape(string gameMode)
    {



        //Debug.Log(gameMode);

        catcherScripts = thisSceneMgr.myCatcherManager.myCatchersScripts;
        catchersColors = thisSceneMgr.myCatcherManager.myColors;


        if (gameMode == "shapes")
        {

            int shapeIndex = UnityEngine.Random.Range(0, catcherScripts.Length);
            int colorIndex = UnityEngine.Random.Range(0, baseColors.Length);

            for (int j = 0; j < baseShapes.Length; j++)
            {
                Mover thisMover = baseShapes[j].GetComponent<Mover>();

                if (thisMover.moverShape == catcherScripts[shapeIndex].catcherShape)
                {

                    activeShape = (GameObject)Instantiate(baseShapes[j], Vector3.zero, Quaternion.identity);

                    thisSceneMgr.shapeExist = true;
                    activeShape.GetComponent<Mover>().moverColor = baseColors[colorIndex];
                    activeShape.GetComponent<Mover>().moverSprite.color = baseColors[colorIndex];
                    break;

                }
            }

        }
        else if (gameMode == "colors")
        {
            int shapeIndex = UnityEngine.Random.Range(0, baseShapes.Length);
            int colorIndex = UnityEngine.Random.Range(0, catchersColors.Length);
            reshuffle(catchersColors);

            activeShape = (GameObject)Instantiate(baseShapes[shapeIndex], Vector3.zero, Quaternion.identity);

            thisSceneMgr.shapeExist = true;
            activeShape.GetComponent<Mover>().moverColor = catchersColors[colorIndex];
            activeShape.GetComponent<Mover>().moverSprite.color = catchersColors[colorIndex];


        }
        else if (gameMode == "both")
        {

            int shapeIndex = UnityEngine.Random.Range(0, catcherScripts.Length);
            //	int colorIndex= UnityEngine.Random.Range(0,baseColors.Length);

            for (int j = 0; j < baseShapes.Length; j++)
            {
                Mover thisMover = baseShapes[j].GetComponent<Mover>();

                if (thisMover.moverShape == catcherScripts[shapeIndex].catcherShape)
                {

                    activeShape = (GameObject)Instantiate(baseShapes[j], Vector3.zero, Quaternion.identity);

                    thisSceneMgr.shapeExist = true;
                    activeShape.GetComponent<Mover>().moverColor = catcherScripts[shapeIndex].catcherColor;
                    activeShape.GetComponent<Mover>().moverSprite.color = catcherScripts[shapeIndex].catcherColor;
                    break;
                }
            }

        }

    }



    int randShapeIndex(int lst, int max)
    {

        int i = UnityEngine.Random.Range(0, max);
        if (i == lst)
        {
            return randShapeIndex(lst, max);
        }
        else
        {
            return i;

        }
    }


    void reshuffle(Color[] objs)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < objs.Length; t++)
        {
            Color tmp = objs[t];
            int r = UnityEngine.Random.Range(t, objs.Length);
            objs[t] = objs[r];
            objs[r] = tmp;
        }
    }


}




