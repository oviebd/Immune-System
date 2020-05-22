using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryCollisionDetector : MonoBehaviour,IColliderEnter
{
    public void onCollide(GameObject collidedObj)
    {
        if(collidedObj.tag == GameEnum.GameTags.Enemy.ToString())
        {
            EnemyBehaviourBase enemyBehaviour = collidedObj.GetComponent<EnemyBehaviourBase>();

            if(enemyBehaviour != null)
            {
                enemyBehaviour.SetIsEnemyEnteredGameSceneValue(true);
                IGunController gunController = enemyBehaviour.GetGunController();
                if(gunController != null)
                    gunController.StartShooting(0.3f);
            }
        }
       
    }

   
}
