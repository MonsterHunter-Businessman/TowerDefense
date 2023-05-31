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
            Debug.Log("����ȭ���Ӥ���");
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
                Debug.Log("�Ѿ�ϴ�");
                break;

            case Btntype.Quit:
                Debug.Log("�����մϴ�");
                Application.Quit();
                break;

            case Btntype.accept:
                break;

            case Btntype.Buy:
                int cardIndex = (int)card.TowerCard;

                if (GameDataManager.Instance.GameMoney < Cards.CardPrice)
                {
                    Popup.SetActive(true);
                    Debug.Log("���� �����Ͽ� ������ �� �����ϴ�.");
                }
                else if (card.hasCard[cardIndex] == 0)
                {
                    Debug.Log("���� ����");
                    GameDataManager.Instance.GameMoney -= Cards.CardPrice;
                    card.hasCard[cardIndex] = 1;
                    Debug.Log(card.CardNametxt + " ī�带 �����߽��ϴ�.");
                }
                else
                {
                    Popup.SetActive(true);
                    Debug.Log(card.CardNametxt + " ī�带 �̹� ���� ���Դϴ�.");
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
                Debug.Log("������");
                break;
        }
    }
}
