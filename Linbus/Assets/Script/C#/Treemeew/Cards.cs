using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//개선사항이 많이 필요
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
    public bool[] hasCard; // 수정된 부분: 배열을 bool 타입으로 변경

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
                CardNametxt = "사제";
                CardInfo = " 10초마다 아군의 체력을 5회복 합니다.적을 단일 공격합니다.";
                CardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Img/Treemeew/nun");
                CardPrice = 200;
                CardDmg = 7;
                break;
            case TowerCards.assassin:
                CardNametxt = "암살자";
                CardInfo = " 상대에게 공격을 받지 않습니다.적을 단일 공격합니다";
                CardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Img/Treemeew/assassin");
                CardPrice = 100;
                CardDmg = 15;
                break;
            case TowerCards.spear:
                CardNametxt = "창병";
                CardInfo = "상대의 어그로를 우선으로 먹습니다.적을 단일 공격합니다.";
                CardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Img/Treemeew/spear");
                CardPrice = 500;
                CardDmg = 10;
                break;
        }
  
    }

}

