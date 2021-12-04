using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] points;
    public GameObject monsterPrefab;

    void Start()
    {
        points = GameObject.Find("SpawnPointGroup")?.GetComponentsInChildren<Transform>();
        // monsterPrefab = Resources.Load("Monster") as GameObject;
        monsterPrefab = Resources.Load<GameObject>("Prefabs/Monster");

        // GameObject obj = GameObject.Find("SpawnPointGroup");  
        // if (obj != null)
        // {
        //     points = obj.GetComponentsInChildren<Transform>();
        // }     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
