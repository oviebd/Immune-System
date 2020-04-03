using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAble : MonoBehaviour
{
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
