using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    // 열거형 변수 정의
    public enum State
    {
        IDLE, TRACE, ATTACK, DIE
    }
    // 몬스터의 상태
    public State state = State.IDLE;
    
    // 추적 사정거리
    [Range(10.0f, 50.0f)]
    public float traceDist = 10.0f;

    // 공격 사정거리
    public float attackDist = 2.0f;

    [System.NonSerialized] //C#
    public Transform monsterTr;
    [HideInInspector]  //UnityEngine
    public Transform playerTr;

    private NavMeshAgent agent;
    private Animator anim;

    public bool isDie = false;

    private int hashTrace;
    private int hashAttack;

    void Start()
    {
        // Animator View의 HashTable의 Hash 값을 미리 추출
        hashTrace = Animator.StringToHash("IsTrace");
        hashAttack = Animator.StringToHash("IsAttack");

        monsterTr = GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        StartCoroutine(CheckState());
        StartCoroutine(MonsterAction());
    }

    IEnumerator CheckState()
    {
        while (isDie == false)
        {
            // 두 3차원 좌표간의 거리를 측정
            float distance = Vector3.Distance(monsterTr.position, playerTr.position);

            if (distance <= attackDist)
            {
                state = State.ATTACK;
            }
            else if (distance <= traceDist)
            {
                state = State.TRACE;
            }
            else
            {
                state = State.IDLE;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator MonsterAction()
    {
        while(!isDie) // (isDie == false)
        {
            switch (state)
            {
                case State.IDLE:
                    agent.isStopped = true;
                    anim.SetBool("IsTrace", false); // Walk -> Idle
                    break;

                case State.TRACE:
                    agent.SetDestination(playerTr.position);
                    agent.isStopped = false;
                    anim.SetBool("IsTrace", true); // Idle -> Walk
                    break;

                case State.ATTACK:
                    Debug.Log("공격");
                    break;

                case State.DIE:
                    break;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
}
