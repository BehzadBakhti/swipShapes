using UnityEngine;

public class MyTouchMgr : MonoBehaviour/*, IPointerDownHandler, IDragHandler, IPointerUpHandler*/
{
    public GameObject myGameObj;
    public SceneMgr thisSceneMgr;
    public float speadFactor;
    Vector3 offset;
    Vector3 target = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        //myGameObj=this.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            target = Vector3.zero;
            Ray mousRay = Camera.main.ScreenPointToRay(Input.mousePosition);//new Ray(mousPosN, mousPosF-mousPosN);
            RaycastHit hit;
            if (Physics.Raycast(mousRay, out hit))
            {
                GameObject toched = hit.transform.gameObject;
                if (toched.tag == "candy")
                {
                    myGameObj = toched;
                    offset = hit.point - myGameObj.transform.position;
                }

            }

        }
        else if (Input.GetMouseButton(0) && myGameObj)
        {

            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            myGameObj.transform.position = new Vector3(newPos.x - offset.x, newPos.y - offset.y, myGameObj.transform.position.z);

        }
        else if (Input.GetMouseButtonUp(0) && myGameObj)
        {


            float dist = 100f;
            float centerDist = 0f;
            float currObjDist = 0f;
            for (int i = 0; i < thisSceneMgr.pointCounts; i++)
            {
                currObjDist = Vector3.Distance(myGameObj.transform.position, thisSceneMgr.corners[i]);
                centerDist = myGameObj.transform.position.magnitude;
                if (currObjDist < dist)
                {
                    target = thisSceneMgr.corners[i];
                    dist = currObjDist;
                }
            }
            if (centerDist < 0.8f)
            {
                target = Vector3.zero;
            }


        }
        if (myGameObj)
        {
            myGameObj.transform.position = Vector3.Lerp(myGameObj.transform.position, target, speadFactor * Time.deltaTime);
        }

    }

}
