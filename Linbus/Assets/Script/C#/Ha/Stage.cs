using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject ehsRktm;

    public Transform mS;

    public int[] stage = new int[] {5, 7, 9, 10};

    Vector3[] stO = { new Vector3 { x = 7, y = 0, z = 0 }, new Vector3 { x = -7, y = 0, z = 0 } };

    void Start()
    {
        InvokeRepeating("monsterSp", 5f, 2f);
    }

    void monsterSp()
    {

        Instantiate(ehsRktm, mS.transform);




    }




    void Update()
    {
        //yield return new WaitForSeconds(1);
    }


}


