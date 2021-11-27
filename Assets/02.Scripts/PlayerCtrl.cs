using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float turnSpeed = 80.0f;

    private float _turnSpeed;

    private Animation anim;

    // 1회 호출되는 함수
    IEnumerator Start()
    {
        // Animation 컴포넌트 추출
        anim = GetComponent<Animation>(); //제너릭 문법
        //anim = GetComponent("Animation") as Animation;
        anim.Play("Idle");

        _turnSpeed = 0;

        yield return new WaitForSeconds(0.2f);
        _turnSpeed = turnSpeed;

        /*
        메소드(함수)
        객체.대문자(인자);

        프로퍼티(속성)
        객체.소문자 = 값;
        */
    }

    // 화면을 렌더링하는 주기
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // 좌/우 화살표 키 값을 입력 -1.0f ~ 0.0f ~ +1.0f
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");
        // Debug.Log("h=" + h); //콘솔 뷰에 출력
        // Debug.Log("v=" + v);

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(moveDir.normalized * Time.deltaTime * moveSpeed);
        transform.Rotate(Vector3.up * Time.deltaTime * r * _turnSpeed);

        PlayerAnimation(h, v);
    }

    // Player Animation 처리 로직
    void PlayerAnimation(float h, float v)
    {
        // 전진/후진
        if (v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.3f); // 전진 애니메이션
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.3f); // 후진 애니메이션
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade("RunR", 0.3f); // 오른쪽 
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("RunL", 0.3f); // 왼쪽
        }
        else
        {
            anim.CrossFade("Idle", 0.3f);
        }
    }

}
