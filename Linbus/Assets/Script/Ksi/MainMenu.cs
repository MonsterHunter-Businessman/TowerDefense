using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public int userLv = 1;
    public float userExp = 0;

    public Image TestImage; //기존에 존제하는 이미지
    public Sprite[] TestSprite; //바뀌어질 이미지

    private int spriteIndex = 0;

    private string userName = "user";

    public enum ButtonType { 
        Left,
        Right 
    };

    public TMP_Text tmp;


    public void ChangeCharacter(string direction)
    {
        if (direction == "Right")
        {
            Debug.Log("Right " + spriteIndex);
            spriteIndex = spriteIndex >= TestSprite.Length - 1 ? 0 : spriteIndex + 1;
        }
        else if (direction == "Left")
        {
            Debug.Log("Left " + spriteIndex);
            spriteIndex = spriteIndex <= 0 ? TestSprite.Length - 1 : spriteIndex - 1;
        }
        TestImage.GetComponent<Image>().sprite = TestSprite[spriteIndex];
    }

    public void GotoDeck()
    {
        Debug.Log("GotoDeck");
        //SceneManager.LoadScene("Deck");
    }

    public void ChangeUserName(string newName)
    {
        this.userName = newName;
        tmp.text = this.userName;
    }

    // Start is called before the first frame update
    void Start()
    {
        tmp.text = this.userName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
