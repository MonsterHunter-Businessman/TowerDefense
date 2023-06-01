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

        // card 변수가 null이면 처리 중지
        if (card == null)
            return;

        // 보유 중인 카드를 보고 있다면 Panel 활성화
        bool hasCard = card.hasCard[(int)card.TowerCard] > 0;
        Panel.SetActive(hasCard);
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

                if (GameDataManager.Instance.GameMoney < Cards.CardPrice)
                {
                    Popup.SetActive(true);
                    Debug.Log("돈이 부족하여 구매할 수 없습니다.");
                }
                else if (card.hasCard[cardIndex] == 0)
                {
                    Debug.Log("구매 성공");
                    GameDataManager.Instance.GameMoney -= Cards.CardPrice;
                    card.hasCard[cardIndex] += 1;
                    card.hasCard[card.CardIndex] += 1;
                    Debug.Log(card.CardNametxt + " 카드를 구매했습니다.");

                }
                else
                {

                    Debug.Log(card.CardNametxt + " 카드를 이미 보유 중입니다.");
                }
                break;

            case Btntype.CardUp:
                if (card.CardIndex + 1 >= 15)
                {
                    return;
                }
                Panel.SetActive(false);
                cardIndex++;
                card.CardIndex = cardIndex;
                break;

            case Btntype.CardDown:
                if (card.CardIndex - 1 < 0)
                {
                    return;
                }
                card.CardIndex--;
                break;

            case Btntype.None:
                Debug.Log("실행함");
                break;
        }
    }
}
