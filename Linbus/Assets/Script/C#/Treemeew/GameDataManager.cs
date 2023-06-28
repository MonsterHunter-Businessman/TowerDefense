using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameDataManager : MonoBehaviour
{

    public static GameDataManager Instance = null;

    public int PlayerLv =1;
    public float PlayerExp;
    public int GameMoney = 999;

    public TMP_InputField PlayerName;
    public TMP_InputField PlayerInfoTxt;
    


    public void PlayerInfoSave()
    {
        PlayerPrefs.SetString("Name", PlayerName.text);
        PlayerPrefs.SetString("Info", PlayerInfoTxt.text);
    }

    public void PlayerInfoLoad()
    {
        if (PlayerPrefs.HasKey("Name"))
        {
            PlayerName.text = PlayerPrefs.GetString("Name");
            PlayerInfoTxt.text = PlayerPrefs.GetString("Info");
        }
    }


    void Start()
    {
        if (Instance == null) {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        PlayerInfoLoad();
    }

}
