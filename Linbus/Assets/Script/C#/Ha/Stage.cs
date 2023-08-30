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

    Vector3[] st1 = { new Vector3 { x = 7, y = 0, z = 0 }, new Vector3 { x = 0, y = 0, z = 0 }, new Vector3 { x = -7, y = 0, z = 0 } };

    Vector3[] st2 = { new Vector3 { x = 9, y = 0, z = 0 }, new Vector3 { x = 3, y = 0, z = 0 }, new Vector3 { x = 3, y = -1, z = 0 }, new Vector3 { x = 1, y = -1, z = 0 }, new Vector3 { x = 1, y = 0, z = 0 }, new Vector3 { x = -2, y = 0, z = 0 } };

    public float spawnInterval = 2f; // 복제 간격 (초)
    public int spawnCount = 5;       // 복제할 횟수

    private int spawnCounter;        // 현재 복제한 횟수

    void Start()
    {
        StartCoroutine(SpawnGoblins());
    }

    private IEnumerator SpawnGoblins()
    {

        if (stage == 1) {
            while (spawnCounter < 5) {
                monsterB = Instantiate(goblin, mS.transform);

                monsterB.transform.parent = parent.transform;

                monsterB.GetComponent<Monster>().pathval = new Vector3[2];
                monsterB.GetComponent<Monster>().pathval = st1;

                spawnCounter++;

                yield return new WaitForSeconds(spawnInterval);
            }
        }
        else if (stage == 2) {
            while (spawnCounter < 7) {
                monsterB = Instantiate(goblin, mS.transform);

                monsterB.transform.parent = parent.transform;

                monsterB.GetComponent<Monster>().pathval = new Vector3[6];
                monsterB.GetComponent<Monster>().pathval = st2;

                spawnCounter++;

                yield return new WaitForSeconds(spawnInterval);
            }
        }

        


    }

    //GameObject.Find("스크립트를 포함하는 오브젝트이름").GetComponent<스크립트 이름>().변수


    void Update()
    {
        //yield return new WaitForSeconds(1);
    }


}


