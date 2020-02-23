using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatorHelper : MonoBehaviour {

	public  static GameObject InstantiateObject(GameObject obj, GameObject parentObj)
	{
		Vector3 parentPos = parentObj.transform.position;
		GameObject newObj = Instantiate(obj, parentObj.transform,false);
	  // newObj.transform.parent = parentObj.transform;
		return newObj;
	}
}
