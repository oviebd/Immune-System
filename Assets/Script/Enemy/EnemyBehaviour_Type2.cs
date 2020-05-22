using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour_Type2 : EnemyBehaviourBase, IENemyBehaviour
{
	float _angle;
	float stoppingDistance = 3.0f;

	private void Awake()
	{
		SetEnemyBehaviour(this);
	}


    public void OnTargetFound(GameObject targetObj)
    {
        Transform targetTransform = targetObj.transform;
		SetInitialTarget(targetTransform);

        IMove[] moves = Utils.GetAllIMoveComponentsFromAGameObject(this.gameObject);
        if (moves == null)
            return;
		for (int i = 0; i < moves.Length; i++)
        {
			IMove move = moves[i];

			move.Setup(targetObj, 3.0f);
			move.SetTargetObject(targetObj);
			move.SetAngle(_angle);
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

    public void OnDestroyObject()
    {
       
    }

    public void OnMovementStop()
    {
        SetInactiveMode();
    }
}
