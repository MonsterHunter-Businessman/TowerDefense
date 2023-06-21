using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    private GameObject TXT;

    private GameObject Tower;
    private GameObject TowerRange;
    private Transform TowerSp;

    void Start()
    {
        TXT = GameObject.Find("TowerOne");
        TowerRange = GameObject.Find("Test_Tower_Range");
        Tower = GameObject.Find("Test_Tower");

        TowerSp = Tower.GetComponent<Tuttey>().TowerSp;
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickEnd()
    {
        SceneManager.LoadScene("DragAndDrop");
    }

    public void OnClickaInstallation()
    {
        GameObject.Find("Test_Tower").GetComponent<Tuttey>().installation = false;
        TXT.SetActive(false);
    }

    public void OnClickBack()
    {
        Tower.transform.position = new Vector2(-14, -8);
        TXT.SetActive(false);
        TowerRange.SetActive(false);
    }

    //GameObject.Find("스크립트를 포함하는 오브젝트이름").GetComponent<스크립트 이름>().변수

}
