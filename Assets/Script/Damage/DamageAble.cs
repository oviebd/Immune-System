using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add This script to any object, which can damage other Objec.
public class DamageAble : MonoBehaviour
{
    [Header("How much Damage this object can do if it collides with another Object")]
    [SerializeField] private int _damage = 1;

    public int GetDamage()
    {
        return _damage;
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
}
