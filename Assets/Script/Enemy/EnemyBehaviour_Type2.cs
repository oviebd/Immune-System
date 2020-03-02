using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour_Type2 : EnemyBehaviourBase, IENemyBehaviour
{
    GunController gunController = null;

    public void OnMovementStop()
    {
        Shoot();
    }

    public void OnTargetFound(GameObject targetObj)
    {
        Transform targetTransform = targetObj.transform;
        IMove[] moves = gameObject.GetComponents<IMove>();

        for (int i = 0; i < moves.Length; i++)
        {
            moves[i].Setup(targetTransform);
        }
    }

    void Shoot()
    {
       if(gunController == null)
            gunController = this.gameObject.GetComponent<GunController>();

        if (gunController != null)
        {
            gunController.Shoot();

        }
    }
}
