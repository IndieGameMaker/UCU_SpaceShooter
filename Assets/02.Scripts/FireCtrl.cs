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

    private RaycastHit hit;

    // 매 프레임 마다 호출되는 메소드(함수)
    void Update()
    {
        // 광선의 시각화
        Debug.DrawRay(firePos.position, firePos.forward * 10.0f, Color.green);

        if (Input.GetMouseButtonDown(0) == true)
        {
            Fire();

            if (Physics.Raycast(firePos.position, firePos.forward, out hit, 10.0f, 1 << 8)) //2^8=256
            {
                //데미지를 전달
                hit.collider.GetComponent<MonsterCtrl>().OnDamage(25.0f);
            }
        }
    }

    void Fire()
    {
        // 총알 생성
        // Instantiate(생성할객체, 위치, 회전각도)
        // Instantiate(bulletPrefab, firePos.position, firePos.rotation);
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
        // 오프셋 값 변경
        Vector2 offset = new Vector2(Random.Range(0, 2), Random.Range(0, 2)) * 0.5f;
        renderer.material.mainTextureOffset = offset;

        // 회전처리
        float angle = Random.Range(0.0f, 360.0f);
        //[컴포넌트].transform
        renderer.transform.localRotation = Quaternion.Euler(Vector3.forward * angle);

        // 스케일 변경
        float scale = Random.Range(1.0f, 3.0f);
        renderer.transform.localScale = Vector3.one * scale; // new Vector3(scale, scale, scale);

        // MuzzleFlash 활성화
        renderer.enabled = true;

        // 잠시 기다리는 코드
        yield return new WaitForSeconds(0.3f);

        // MuzzleFlash 비활성화
        renderer.enabled = false;
    }
}
