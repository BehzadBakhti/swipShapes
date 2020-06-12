using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuCtrl : MonoBehaviour
{


    public void StartGame()
    {
        GameManager.instance.myAudioMgr.clickSound();
        SceneManager.LoadScene("level1");
    }

    public void SettingsPage()
    {
        GameManager.instance.myAudioMgr.clickSound();
        SceneManager.LoadScene("settings");
    }


    public void ShopPage()
    {
        GameManager.instance.myAudioMgr.clickSound();
        SceneManager.LoadScene("Shop");
    }
    public void QuitGame()
    {
        GameManager.instance.myAudioMgr.clickSound();
        Application.Quit();
    }


    ///if (Input.GetKeyDown(KeyCode.Escape)) { }

}
