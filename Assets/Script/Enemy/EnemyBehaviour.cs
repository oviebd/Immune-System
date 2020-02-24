using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject playerObj;

    void Start()
    {
        // transform.LookAt(playerObj.transform);
        look();
    }
    private void Update()
    {
        //look();
    }

    void look()
    {
        Vector3 dir = playerObj.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
