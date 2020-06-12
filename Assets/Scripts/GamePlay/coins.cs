using UnityEngine;

public class coins : MonoBehaviour
{
    public coinCollector collector;
    private float speedFactor = 10f;

    private bool isCollected = false;
    // Use this for initialization
    void Start()
    {
        collector = FindObjectOfType<coinCollector>();

    }
    void OnTriggerEnter(Collider obj)
    {

        if (obj.gameObject.tag == "candy")
        {

            isCollected = true;
        }

    }

    void Update()
    {
        if (isCollected)
        {

            this.transform.position = Vector3.Lerp(this.transform.position, collector.transform.position, speedFactor * Time.deltaTime);
        }

    }

}
