using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//���������� ���� �ʿ�
public enum TowerCards
{
    none,
    nun,
    assassin,
    spear,
    berserker,
    darkmagician
}

public class Cards : MonoBehaviour
{
    public int CardIndex;
    public TextMeshProUGUI Cardname;
    public TextMeshProUGUI Carddescription;
    public TowerCards TowerCard;
    public static int CardDmg;
    public string CardNametxt;
    public string CardInfo;
    Button Button;
    public static int CardPrice;
    public GameObject CardImage;
    public bool[] hasCard; // ������ �κ�: �迭�� bool Ÿ������ ����

    private void Start()
    {
        hasCard = new bool[System.Enum.GetValues(typeof(TowerCards)).Length];
    }

    void Update()
    {    
        mercenaryType();
        Cardname.text = CardNametxt;
        Carddescription.text = CardInfo;
    }
    public void mercenaryType()
    {
        switch (CardIndex)
        {
            case 0:
                TowerCard = TowerCards.nun;
                break;
            case 1:
                TowerCard = TowerCards.assassin;
                break;
            case 2:
                TowerCard = TowerCards.spear;
                break;
            default:
                TowerCard = TowerCards.none;
                break;
        }
        switch (TowerCard)
        {
            case TowerCards.nun:
                CardNametxt = "����";
                CardInfo = " 10�ʸ��� �Ʊ��� ü���� 5ȸ�� �մϴ�.���� ���� �����մϴ�.";
                CardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Img/Treemeew/nun");
                CardPrice = 200;
                CardDmg = 7;
                break;
            case TowerCards.assassin:
                CardNametxt = "�ϻ���";
                CardInfo = " ��뿡�� ������ ���� �ʽ��ϴ�.���� ���� �����մϴ�";
                CardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Img/Treemeew/assassin");
                CardPrice = 100;
                CardDmg = 15;
                break;
            case TowerCards.spear:
                CardNametxt = "â��";
                CardInfo = "����� ��׷θ� �켱���� �Խ��ϴ�.���� ���� �����մϴ�.";
                CardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Img/Treemeew/spear");
                CardPrice = 500;
                CardDmg = 10;
                break;
        }
  
    }

}

