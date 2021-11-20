#pragma warning disable IDE0051

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    private int hitCount;
    public GameObject expEffect;

    [SerializeField]
    private new MeshRenderer renderer;

    public Texture[] textures;

    void Start()
    {
        renderer = this.gameObject.GetComponentInChildren<MeshRenderer>();

        // 텍스처를 랜덤하게 추출
        int idx = Random.Range(0, textures.Length); // (0, 3) => 0,1,2
        renderer.material.mainTexture = textures[idx];
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            if (++hitCount == 3)
            {
                ExpBarrel();
            }
            /*
            hitCount = hitCount + 1;
            if (hitCount == 3)
            {
            }
            */
        }
    }

    void ExpBarrel()
    {
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 1800.0f);
        Destroy(this.gameObject, 2.0f);

        // 폭발 파티클 생성
        GameObject effect = Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4.0f);
    }
}
