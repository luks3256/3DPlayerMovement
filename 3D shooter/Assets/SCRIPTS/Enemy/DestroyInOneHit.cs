using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInOneHit : MonoBehaviour, IDamageble
{
    public void DealDamage(int damage)
    {
        Destroy(gameObject);
    }
}
