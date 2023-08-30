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
    public GameObject CardImage;
    public int[] hasCard; // ������ �κ�: �迭�� bool Ÿ������ ����

    private void Start()
    {
        hasCard = new int[System.Enum.GetValues(typeof(TowerCards)).Length];
        CardIndex = 1;
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
                TowerCard = TowerCards.none;
                break;
            case 1:
                TowerCard = TowerCards.nun;
                break;
            case 2:
                TowerCard = TowerCards.assassin;
                break;
            case 3:
                TowerCard = TowerCards.spear;
                break;
            case 4:
                TowerCard = TowerCards.berserker;
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
                CardDmg = 7;
                break;
            case TowerCards.assassin:
                CardNametxt = "�ϻ���";
                CardInfo = " ��뿡�� ������ ���� �ʽ��ϴ�.���� ���� �����մϴ�";
                CardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Img/Treemeew/assassin");
                CardDmg = 15;
                break;
            case TowerCards.spear:
                CardNametxt = "â��";
                CardInfo = "����� ��׷θ� �켱���� �Խ��ϴ�.���� ���� �����մϴ�.";
                CardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Img/Treemeew/spear");
                CardDmg = 10;
                break;
            case TowerCards.berserker:
                CardNametxt = "������";
                CardInfo = "����� ��׷θ� �켱���� �Խ��ϴ�.���� ���� �����մϴ�.";
                CardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Img/Treemeew/berserker");
                break;
        }
  
    }

}

