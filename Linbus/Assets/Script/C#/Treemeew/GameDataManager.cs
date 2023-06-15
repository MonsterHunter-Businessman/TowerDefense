using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{

    public static GameDataManager Instance = null;

    public int PlayerLv =1;
    public float PlayerExp;
    public int GameMoney = 999;

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

}
