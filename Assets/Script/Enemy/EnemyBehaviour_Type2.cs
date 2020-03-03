using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour_Type2 : EnemyBehaviourBase, IENemyBehaviour
{
    GunController gunController = null;
	
	bool isReachedDestination = false;
	float _angle;
	float stoppingDistance = 3.0f;

	public void OnMovementStop()
    {
        Shoot();
    }

    public void OnTargetFound(GameObject targetObj)
    {
        Transform targetTransform = targetObj.transform;
        IMove[] moves = gameObject.GetComponents<IMove>();
		SetInitialTarget(targetTransform);

		for (int i = 0; i < moves.Length; i++)
        {
			IMove move = moves[i];

			move.Setup(targetPos, 3.0f);
			move.SetTargetTransform(targetTransform);
			move.SetAngle(_angle);
			move.Run();
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

	void SetInitialTarget(Transform target)
	{
		_angle = MathHandler.GetAngle(target.position, transform); // In Degree
		_angle = _angle * Mathf.Deg2Rad;
		float _posX = Mathf.Cos(_angle) * stoppingDistance;
		float _posY = Mathf.Sin(_angle) * stoppingDistance;

		targetPos = new Vector2(_posX, _posY);
	}
}
