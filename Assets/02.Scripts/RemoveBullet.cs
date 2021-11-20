using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    // 충돌했을 때 1번 호출되는 콜백메소드
    void OnCollisionEnter(Collision coll)
    {
        // 충돌한 객체가 총알인지 여부를 확인
        if (coll.collider.tag == "BULLET")
        {
            // 총알을 삭제
            Destroy(coll.gameObject);

            // 충돌 좌표
            Vector3 pos = coll.GetContact(0).point;
            // 충돌 지점의 법선 벡터
            Vector3 _normal = coll.GetContact(0).normal;
            // 법선 벡터가 이루는 각도를 쿼터니언 타입으로 변환
            Quaternion rot = Quaternion.LookRotation(-1 * _normal);
            // 스파크 이펙트 생성
            Instantiate(sparkEffect, pos, rot);
        }
    }
}
