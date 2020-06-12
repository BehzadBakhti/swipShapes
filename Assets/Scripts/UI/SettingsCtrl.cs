using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsCtrl : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void BackToMainMenue()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
