#pragma warning disable IDE0051

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    private int hitCount;

    void Start()
    {

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

    }


}
