using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    private Animation anim;

    // 1회 호출되는 함수
    void Start()
    {
        // Animation 컴포넌트 추출
        anim = GetComponent<Animation>();
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
        transform.Rotate(Vector3.up * Time.deltaTime * r * 80.0f);
    }

}
