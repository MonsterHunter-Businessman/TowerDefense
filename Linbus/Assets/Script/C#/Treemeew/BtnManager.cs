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
            Debug.Log("����ȭ���Ӥ���");
            SceneLoad.LoadScene("Main");
        }

        // card ������ null�̸� ó�� ����
        if (card == null)
            return;

        // ���� ���� ī�带 ���� �ִٸ� Panel Ȱ��ȭ
        bool hasCard = card.hasCard[(int)card.TowerCard] > 0;
        Panel.SetActive(hasCard);
    }

    public void OnBtnClick()
    {



        switch (Currenttype)
        {
            case Btntype.Start:
                SceneLoad.LoadScene("ReadyScene");
                Debug.Log("�Ѿ�ϴ�");
                break;

            case Btntype.Quit:
                Debug.Log("�����մϴ�");
                Application.Quit();
                break;

            case Btntype.accept:
                break;

            case Btntype.Buy:

                if (GameDataManager.Instance.GameMoney < Cards.CardPrice)
                {
                    Popup.SetActive(true);
                    Debug.Log("���� �����Ͽ� ������ �� �����ϴ�.");
                }
                else if (card.hasCard[cardIndex] == 0)
                {
                    Debug.Log("���� ����");
                    GameDataManager.Instance.GameMoney -= Cards.CardPrice;
                    card.hasCard[cardIndex] += 1;
                    card.hasCard[card.CardIndex] += 1;
                    Debug.Log(card.CardNametxt + " ī�带 �����߽��ϴ�.");

                }
                else
                {

                    Debug.Log(card.CardNametxt + " ī�带 �̹� ���� ���Դϴ�.");
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
                Debug.Log("������");
                break;
        }
    }
}
