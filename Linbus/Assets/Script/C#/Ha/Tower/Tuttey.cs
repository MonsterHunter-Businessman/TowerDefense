using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tuttey : MonoBehaviour
{

    public Vector3 EAsports;

    public Transform target;

    public Transform partToRotate;

    public float Pokemon;

    public float turnSpeed;



    public Vector2 targetPostion;

    public Vector3 mPosition;

    public GameObject range;

    public bool yes;


    public float fireRate = 2f;
    public float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;


    public GameObject TXT;


    public int health;

    public bool installation;

    public Transform TowerSp;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, EAsports);
    }

    void Start() {

        TXT.SetActive(false);
        range.SetActive(false);

        TowerSp = transform;

        installation = true;

        Pokemon = EAsports.x;

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update() {


        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ���콺 ��ǥ ����

        if (target == null) {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, 0f, rotation.z);


        if (fireCountdown <= 0f) {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
        
    }

    void Shoot()
    {
        //Debug.Log("����");
        GameObject bulletGo =  (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Test_Monster");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= Pokemon) {
            target = nearestEnemy.transform;
        } else {
            target = null;
        }

    }

    void OnMouseDrag() 
    {
        if (installation) {


            if (installation) {
                gameObject.transform.position = new Vector2(mPosition.x, mPosition.y);
            }

            range.SetActive(true);

            range.transform.position = gameObject.transform.position;

        }

    }

    void OnMouseUp()
    {

        if (installation) {

            transform.position = targetPostion;

            range.transform.position = new Vector2(targetPostion.x, targetPostion.y);

            TXT.SetActive(false);
        }

        if (yes) {
            EAsports = new Vector3(6, 6, 6);

            if (installation)
            {
                gameObject.tag = "Tower";
                Pokemon = 6;
                TXT.SetActive(true);
            }

        }

        //GameObject towerGo = Instantiate(Resources.Load<GameObject>("Prefabs/tower"), target) as GameObject; 

    }

    void OnMouseDown()
    {
        if (!installation)
        {
            gameObject.tag = "Untagged";
            Pokemon = 0;
            TXT.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "DropArea") {
            targetPostion = col.transform.position;

            //firePoint = col.transform.position;

            yes = true;
            //Debug.Log(targetPostion);


        } else {
            targetPostion = new Vector2(-14, -8);
            yes = false;
            EAsports = new Vector3(0, 0, 0);

            //Debug.Log("�浹���ϴ���");
            
        }

        if (col.gameObject.tag == "TestMonsterA") {
            Debug.Log("Ÿ���� ���� ���ۤää�");
            health--;
        }

        if (health <= 0) {
            //Debug.Log("Ÿ�� ���� ����?");
            Destroy(range);
            Destroy(gameObject);
        }

    }
}
