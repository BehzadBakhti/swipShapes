using System.Collections.Generic;
using UnityEngine;

public class coinManager : MonoBehaviour
{

    // Use this for initialization
    public GameObject coinPrefab;
    public SceneMgr thisSceneMgr;
    public float rX, rY, rC;

    public List<GameObject> coinsList;

    void Start()
    {
        thisSceneMgr = FindObjectOfType<SceneMgr>();
        coinsList = new List<GameObject>();
    }

    // Update is called once per frame
    public void SpawnCoins(int coinsToSpawn)
    {

        for (int i = 0; i < coinsToSpawn; i++)

        {
            Vector3 rndPos = new Vector3(Random.Range(-rX, rX), Random.Range(-rY, rY - 0.7f), 0);
            float elipticDist = Mathf.Pow(rndPos.x, 2) / Mathf.Pow(rX, 2) + Mathf.Pow(rndPos.y, 2) / Mathf.Pow(rY, 2);
            float circleDist = Vector3.Distance(rndPos, Vector3.zero);
            if (elipticDist < 1 && circleDist > rC)
            {
                coinsList.Add((GameObject)Instantiate(coinPrefab, rndPos, Quaternion.identity));
            }

        }
    }



    public void DestroyCoins()
    {
        for (int i = 0; i < coinsList.Count; i++)
        {
            Destroy(coinsList[i].gameObject);
        }

    }
}
