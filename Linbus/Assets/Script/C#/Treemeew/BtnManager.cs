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
    public static int GameMoney;

    public Btntype Currenttype;
    Transform cardTF;

    Cards card;

    // Start is called before the first frame update
    void Start()
    {
        //card = transform.Find("Shop/Card").GetComponent<Cards>();
        //Debug.Log("card info = "+card);

        
        GameMoney = 999;
        //Popup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartPage"&&Input.GetMouseButtonDown(0))
        {
            Debug.Log("����ȭ���Ӥ���");
            SceneLoad.LoadScene("Main");
        }

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
                //Debug.Log("Cards.CardIndex = "+ card.hasCard[Cards.CardIndex]);

                if (GameMoney - Cards.CardPrice < 0)
                {
                    Popup.SetActive(true);
                }
               /* else if (card.hasCard[Cards.CardIndex] >=1)
                {
                    Popup.SetActive(true);
                }*/
                else if (GameMoney - Cards.CardPrice >= 0)
                {
                    Debug.Log("���ż���");
                    GameMoney -= Cards.CardPrice;
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
