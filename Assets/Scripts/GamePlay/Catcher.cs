using System.Collections;
using UnityEngine;


public class Catcher : MonoBehaviour
{

    // Use this for initialization
    public string catcherShape;
    public Color catcherColor;
    public SceneMgr thisSceneMgr;


    public SpriteRenderer thisSprite;


    void Start()
    {
        thisSceneMgr = FindObjectOfType<SceneMgr>();
        thisSprite = this.gameObject.GetComponent<SpriteRenderer>();
        //defaultColor= thisShape.color;
        thisSceneMgr.contPanel.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider target)
    {

        if (target.gameObject.tag == "coin")
            return;

        Mover targetScript = target.gameObject.GetComponent<Mover>();
        target.gameObject.transform.Translate(Vector3.zero);
        Destroy(target.gameObject);

        if (thisSceneMgr.gameMode == "shapes")
        {
            if ((targetScript.moverShape != this.catcherShape))
            {

                thisSceneMgr.wrongHit = true;

            }

        }
        else if (thisSceneMgr.gameMode == "colors")
        {
            if ((targetScript.moverColor != this.catcherColor))
            {

                thisSceneMgr.wrongHit = true;
            }


        }
        else if (thisSceneMgr.gameMode == "both")
        {
            if (!(targetScript.moverColor == this.catcherColor && targetScript.moverShape == this.catcherShape))
            {

                thisSceneMgr.wrongHit = true;

            }

        }



        if (thisSceneMgr.wrongHit)
        {
            thisSceneMgr.myCoinManager.DestroyCoins();
            thisSceneMgr.GameOver();
            ////
        }
        else
        {
            thisSceneMgr.successEffect.transform.position = this.transform.position;
            thisSceneMgr.successEffect.Play();
            thisSceneMgr.myCoinManager.DestroyCoins();
            thisSceneMgr.myTimeMgr.initTimer();
            thisSceneMgr.shapeExist = false;
            thisSceneMgr.score += 10;
            thisSceneMgr.scoreText.text = thisSceneMgr.score.ToString();
            thisSprite.color = new Color(256, 256, 0);
            StartCoroutine(delay());
            thisSceneMgr.CheckForModeChange();
        }



    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.2f);
        thisSprite.color = catcherColor;
    }




}
