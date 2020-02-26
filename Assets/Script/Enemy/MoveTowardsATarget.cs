using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsATarget : MonoBehaviour,IMove
{
    [SerializeField] private Transform target;
    [SerializeField] private float movingSpeed = 1.0f;

 
    public void Setup(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        MoveTowards();
    }

    private void MoveTowards()
    {
        if(target!= null)
        {
            float step = movingSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
       
    }
}
