using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    // 열거형 변수 정의
    public enum State
    {
        IDLE, TRACE, ATTACK, DIE
    }
    // 몬스터의 상태
    public State state = State.IDLE;

    [System.NonSerialized] //C#
    public Transform monsterTr;
    [HideInInspector]  //UnityEngine
    public Transform playerTr;

    void Start()
    {
        monsterTr = GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
