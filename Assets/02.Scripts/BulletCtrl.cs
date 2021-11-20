using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        // 현재 추가된 게임오브젝트의 Rigidbody 컴포넌트를 추출해서 변수 rb 저장
        rb = GetComponent<Rigidbody>();
        // 힘을 추가 Rigidbody.AddRelativeForce(방향 * 힘);
        rb.AddRelativeForce(Vector3.forward * 800.0f);
    }
}
