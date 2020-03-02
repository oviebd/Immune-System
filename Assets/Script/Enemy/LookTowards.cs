using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowards : MonoBehaviour,IMove
{
    [SerializeField] private Transform target;
    [SerializeField] private bool isAllTimeUpdate = false;

    public void Setup(Transform target)
    {
        this.target = target;

        Look();
    }

    private void Update()
    {
        if (isAllTimeUpdate)
            Look();
    }

    private void Look()
    {
        if(target != null)
        {
            Vector3 dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }
}
