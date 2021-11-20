using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    // 충돌했을 때 1번 호출되는 콜백메소드
    void OnCollisionEnter(Collision coll)
    {
        // 충돌한 객체가 총알인지 여부를 확인
        if (coll.collider.tag == "BULLET")
        {
            // 총알을 삭제
            Destroy(coll.gameObject);
        }
    }
}
