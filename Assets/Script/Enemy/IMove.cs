using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove 
{
    void Setup( GameObject targetObj , float distance);
	void Run();
	void SetTargetObject(GameObject targetObject);
	void SetAngle(float angle);
	void StopMovement();
}
