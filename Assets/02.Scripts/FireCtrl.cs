using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public Transform firePos;
    public GameObject bulletPrefab;

    // 매 프레임 마다 호출되는 메소드(함수)
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            // 총알 생성
            // Instantiate(생성할객체, 위치, 회전각도)
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}
