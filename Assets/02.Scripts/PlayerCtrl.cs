using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    // 1회 호출되는 함수
    void Start()
    {
        
    }

    // 화면을 렌더링하는 주기
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // 좌/우 화살표 키 값을 입력 -1.0f ~ 0.0f ~ +1.0f
        float v = Input.GetAxis("Vertical"); 
        Debug.Log("h=" + h); //콘솔 뷰에 출력
        Debug.Log("v=" + v);
    }

}
