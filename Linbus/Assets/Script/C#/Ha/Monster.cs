using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{

    public PathType pathsystem = PathType.CatmullRom;
    public PathMode pathmode = PathMode.Ignore;
    public int resulution = 10;
    public Color gizmoColor = Color.red;

    public Vector3[] pathval = new Vector3[0];

    public float speed;

    public int health;

    public int damage;

    public float Pokemon;

    private float lateTime = 0f;

    private float pathLength = 0f;

    public float fireCountdown = 0f;

    public float fireRate = 2f;

    private Transform towerTransform;
    private bool isAttackingTower = false;
    private float attackInterval = 5f;
    private float attackTimer = 0f;

    public Transform target;
    public GameObject bulletPrefab;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start() {

        for (int i = 0; i < pathval.Length - 1; i++) {
            pathLength += Vector3.Distance(pathval[i], pathval[i + 1]);
        }

        speed = pathLength / speed;

        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        Invoke("Move", lateTime);

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

        if (target == null)
        {
            return;
        }

        if (fireCountdown <= 0f)
        {
            AttackTower();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;

    }


    //void OnCollisionEnter2D(Collision2D col) {
    void OnTriggerEnter2D(Collider2D col) { 
            
        Debug.Log("�浹�� �ϳ�!!!!!!");

        if (col.gameObject.tag == "Test_Arrow") {
            Debug.Log("����Ÿ");
            health--;
        } else if (col.gameObject.tag == "Player_Spawn") {
            Debug.Log("����");
            Destroy(gameObject);

            GameObject.Find("PlayerManager").GetComponent<PlayerTXT>().score -= damage;
        } 

        if (health <= 0) {
            Debug.Log("�׾���");
            Destroy(gameObject);
        }

    }


    void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Tower");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= Pokemon)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    void AttackTower()
    {
        //Debug.Log("����");
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

}

//GameObject.Find("��ũ��Ʈ�� �����ϴ� ������Ʈ�̸�").GetComponent<��ũ��Ʈ �̸�>().����