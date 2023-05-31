using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{

    public static GameDataManager Instance = null;

    public int PlayerLv;
    public float PlayerExp;


    // ���� ���ž����� ��������
    void Start()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
