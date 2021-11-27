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
    private int hashHit;

    // 몬스터의 HP
    private float hp = 100.0f;

    void Start()
    {
        // Animator View의 HashTable의 Hash 값을 미리 추출
        hashTrace = Animator.StringToHash("IsTrace");
        hashAttack = Animator.StringToHash("IsAttack");
        hashHit = Animator.StringToHash("Hit");

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
            if (state == State.DIE) yield break;

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
                    anim.SetBool(hashTrace, false); // Walk -> Idle
                    break;

                case State.TRACE:
                    agent.SetDestination(playerTr.position);
                    agent.isStopped = false;
                    anim.SetBool(hashTrace, true); // Idle -> Walk
                    anim.SetBool(hashAttack, false); // Attack -> Walk
                    break;

                case State.ATTACK:
                    agent.isStopped = true;
                    anim.SetBool(hashAttack, true); // Walk -> Attack
                    break;

                case State.DIE:
                    isDie = true;
                    agent.isStopped = true;
                    anim.SetTrigger("Die");
                    GetComponent<CapsuleCollider>().enabled = false;
                    break;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject); // 총알을 삭제
            anim.SetTrigger(hashHit);

            hp -= 20.0f;
            if (hp <= 0.0f)
            {
                state = State.DIE;
            }
        }
    }


}
