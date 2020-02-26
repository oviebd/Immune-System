using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IENemyBehaviour 
{
    void OnMovementStop();
    void OnTargetFound(GameObject targetObj);
}
