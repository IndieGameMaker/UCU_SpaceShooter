using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;
    public AudioClip fireSfx;

    [SerializeField]
    private new MeshRenderer renderer;
    private new AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        // MuzzleFlash에 있는 MeshRenderer 컴포넌트를 할당
        renderer = firePos.GetComponentInChildren<MeshRenderer>();
        renderer.enabled = false;
    }

    // 매 프레임 마다 호출되는 메소드(함수)
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            Fire();
        }
    }

    void Fire()
    {
        // 총알 생성
        // Instantiate(생성할객체, 위치, 회전각도)
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        // 총소리 발생
        audio.PlayOneShot(fireSfx, 0.8f);
        // 총구화염 효과
        StartCoroutine(ShowMuzzleFlash());

        /*
            StartCoroutine("ShowMuzzleFlash"); (X)
            StopCoroutine(정지할_코루틴함수)
        */
    }

    // 코루틴으로 구현
    IEnumerator ShowMuzzleFlash()
    {
        // MuzzleFlash 활성화
        renderer.enabled = true;
        
        // 잠시 기다리는 코드
        yield return new WaitForSeconds(0.3f);

        // MuzzleFlash 비활성화
        renderer.enabled = false;
    }
}
