using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject goblin;

    public Transform mS;

    public int stage;

    public GameObject monsterB;

    public GameObject parent;

    public int[] stageMonster = new int[] {5, 7, 9, 10};

    Vector3[] st1 = { new Vector3 { x = 10.24f, y = 0, z = 0 }, new Vector3 { x = 5.12f, y = 0, z = 0}, new Vector3 { x = 0, y = 5.12f, z = 0 },new Vector3 { x = -5.12f, y=0, z=0}, new Vector3 { x = -10.24f, y = 2.56f, z = 0 }, new Vector3 { x = -7.68f, y = 5.12f, z = 0 } };

    Vector3[] st2 = { new Vector3 { x = 9, y = 0, z = 0 }, new Vector3 { x = 3, y = 0, z = 0 }, new Vector3 { x = 3, y = -1, z = 0 }, new Vector3 { x = 1, y = -1, z = 0 }, new Vector3 { x = 1, y = 0, z = 0 }};


    void Start()
    {
        InvokeRepeating("monsterSp", 5f, 2f);
    }

    void monsterSp()
    {

        if (stage == 1) {

            monsterB = Instantiate(goblin, mS.transform);

            monsterB.transform.parent = parent.transform;

            monsterB.GetComponent<MonsterGoblin>().pathval = new Vector3[4];
            monsterB.GetComponent<MonsterGoblin>().pathval = st1;

        }

        


    }

    //GameObject.Find("스크립트를 포함하는 오브젝트이름").GetComponent<스크립트 이름>().변수


    void Update()
    {
        //yield return new WaitForSeconds(1);
    }


}


