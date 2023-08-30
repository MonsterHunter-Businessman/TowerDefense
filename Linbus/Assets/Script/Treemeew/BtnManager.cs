using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public enum Btntype
{
    None,
    Start,
    Quit,
    accept,
    SaveInfo
}

public class BtnManager : MonoBehaviour
{
/*    public GameObject Popup;
    public GameObject Panel;*/
    public Btntype Currenttype;
    public Cards card;


    private int cardIndex;

    void Start()
    {
        cardIndex = (int)card.TowerCard;

        // Popup.SetActive(false);
    }

    void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "StartPage" && Input.GetMouseButtonDown(0))
        {
            Debug.Log("시작화면임ㅇㅇ");
            SceneLoad.LoadScene("Main");
        }

       
    }

    public void OnBtnClick()
    {



        switch (Currenttype)
        {
            case Btntype.Start:
                SceneLoad.LoadScene("ReadyScene");
                Debug.Log("넘어갑니다");
                break;

            case Btntype.Quit:
                Debug.Log("종료합니다");
                Application.Quit();
                break;

            case Btntype.accept:
                break;
            case Btntype.SaveInfo:
                GameDataManager.Instance.PlayerInfoSave();
                break;

            case Btntype.None:
                Debug.Log("실행함");
                break;
        }
    }
}
