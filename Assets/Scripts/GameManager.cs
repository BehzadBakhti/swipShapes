using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioMgr myAudioMgr;

    void Awake()
    {
        MakeSinglton();


    }
    void MakeSinglton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {
        if (!PlayerPrefs.HasKey(GamePrefs.gameInit))
        {
            PlayerPrefs.SetInt(GamePrefs.isMusicOn, 1);
            PlayerPrefs.SetInt(GamePrefs.isSoundEffectsOn, 1);
            PlayerPrefs.SetFloat(GamePrefs.soundVolume, 0.5f);

            PlayerPrefs.SetInt(GamePrefs.userLifes, 10);
            PlayerPrefs.SetInt(GamePrefs.highScore, 0);
            PlayerPrefs.SetInt(GamePrefs.userCoins, 0);

            PlayerPrefs.SetInt(GamePrefs.gameInit, 1);

            PlayerPrefs.SetInt(GamePrefs.lastTimePlayed, 0);
        }

        myAudioMgr = GameObject.Find("AudioManager").GetComponent<AudioMgr>();
    }



    public void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(GamePrefs.lastTimePlayed, (int)DateTimeExtensions.ToUnixTimestamp(System.DateTime.Now));


    }
    public int evaluteLifes()
    {
        int noww = (int)DateTimeExtensions.ToUnixTimestamp(System.DateTime.Now);
        int lastPlay = PlayerPrefs.GetInt(GamePrefs.lastTimePlayed);
        int lifes = PlayerPrefs.GetInt(GamePrefs.userLifes) + (int)((noww - lastPlay) / 180);
        if (lifes > 10)
            lifes = 10;


        return lifes;

    }




}


public static class DateTimeExtensions
{
    public static long ToUnixTimestamp(this DateTime d)
    {
        var epoch = d - new DateTime(1970, 1, 1, 0, 0, 0);

        return (long)epoch.TotalSeconds;
    }
}