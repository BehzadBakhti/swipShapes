using UnityEngine;

public class BGController : MonoBehaviour
{

    // Use this for initialization
    public Sprite[] bgSprites;


    // Update is called once per frame
    public void pickRandomSprite()
    {
        int idx = Random.Range(0, bgSprites.Length);
        this.GetComponent<SpriteRenderer>().sprite = bgSprites[idx];

    }
}
