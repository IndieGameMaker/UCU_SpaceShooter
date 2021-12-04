using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] points;
    public GameObject monsterPrefab;
    public float createTime = 3.0f;

    void Start()
    {
        points = GameObject.Find("SpawnPointGroup")?.GetComponentsInChildren<Transform>();
        monsterPrefab = Resources.Load<GameObject>("Prefabs/Monster"); 
        // 반복 호출
        InvokeRepeating("CreateMonster", 2.0f, createTime);
    }

    void CreateMonster()
    {
        // 불규칙한 위치를 선정(난수 발생)
        int idx = Random.Range(1, points.Length); // 25개 0..24
        // 몬스터 생성 Instantiate
        Instantiate(monsterPrefab, points[idx].position, Quaternion.identity);
    }
}
