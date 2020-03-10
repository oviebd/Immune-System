using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove 
{
    void Setup( Vector3 targetPos , float distance);
	void Run();
	void SetTargetTransform(Transform targetTransform);
	void SetAngle(float angle);
	void StopMovement();
}
