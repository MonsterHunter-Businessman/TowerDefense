using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;

public class MonsterGoblin : MonoBehaviour
{

    public PathType pathsystem = PathType.CatmullRom;
    public PathMode pathmode = PathMode.Ignore;
    public int resulution = 10;
    public Color gizmoColor = Color.red;

    public Vector3[] pathval = new Vector3[0];

    public float speed;

    public int health;

    private float pathLength = 0f;

    // Start is called before the first frame update
    void Start() {

        for (int i = 0; i < pathval.Length - 1; i++) {
            pathLength += Vector3.Distance(pathval[i], pathval[i + 1]);
        }

        speed = pathLength / speed;

        gameObject.SetActive(false);

        Move();
    }


    void Move() {

        gameObject.SetActive(true);
        this.transform.DOPath(pathval, speed, pathsystem, pathmode, resulution, gizmoColor)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                // �̵��� �Ϸ�� �Ŀ� ��ü�� ���� �������� �̵���ŵ�ϴ�.
                this.transform.position = pathval[pathval.Length - 1];
            });
    }

    void Update() {
        //Debug.Log("�� �۵���?");
    }


    void OnCollisionEnter2D(Collision2D col) {

        //Debug.Log("�浹�� �ϳ�?");

        if (col.gameObject.tag == "Test") {
            health--;
        } else if (col.gameObject.tag == "Player_Spawn") {
            Debug.Log("����");
            Destroy(gameObject);
        }

        if (health <= 0) {
            Debug.Log("�׾���");
            Destroy(gameObject);
        }

    }

}

//GameObject.Find("��ũ��Ʈ�� �����ϴ� ������Ʈ�̸�").GetComponent<��ũ��Ʈ �̸�>().����