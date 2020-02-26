using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour_Type1 : EnemyBehaviourBase, IENemyBehaviour
{

    public void OnMovementStop()
    {

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
}
