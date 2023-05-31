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
    Buy,
    CardUp,
    CardDown
}

public class BtnManager : MonoBehaviour
{
    public GameObject Popup;
    public GameObject Panel;
    public Btntype Currenttype;
    public Cards card;

    

    void Start()
    {
        // Popup.SetActive(false);
    }

    void Update()
    {

        if (SceneManager.GetActiveScene().name == "StartPage" && Input.GetMouseButtonDown(0))
        {
            Debug.Log("시작화면임ㅇㅇ");
            SceneLoad.LoadScene("Main");
        }

     /**   if (card.hasCard[cardIndex] != 0)
        {
            Panel.SetActive(true);
        }
        else
            Panel.SetActive(false);**/
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

            case Btntype.Buy:
                int cardIndex = (int)card.TowerCard;

                if (GameDataManager.Instance.GameMoney < Cards.CardPrice)
                {
                    Popup.SetActive(true);
                    Debug.Log("돈이 부족하여 구매할 수 없습니다.");
                }
                else if (card.hasCard[cardIndex] == 0)
                {
                    Debug.Log("구매 성공");
                    GameDataManager.Instance.GameMoney -= Cards.CardPrice;
                    card.hasCard[cardIndex] = 1;
                    Debug.Log(card.CardNametxt + " 카드를 구매했습니다.");
                }
                else
                {
                    Popup.SetActive(true);
                    Debug.Log(card.CardNametxt + " 카드를 이미 보유 중입니다.");
                }
                break;

            case Btntype.CardUp:
                if (Cards.CardIndex + 1 >= 15)
                {
                    return;
                }
                Cards.CardIndex++;
                break;

            case Btntype.CardDown:
                if (Cards.CardIndex - 1 < 0)
                {
                    return;
                }
                Cards.CardIndex--;
                break;

            case Btntype.None:
                Debug.Log("실행함");
                break;
        }
    }
}
