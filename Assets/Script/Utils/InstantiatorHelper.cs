using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatorHelper : MonoBehaviour {

	public  static GameObject InstantiateObject(GameObject obj, GameObject parentObj)
	{
		GameObject newObj = Instantiate(obj, parentObj.transform.position, parentObj.transform.rotation);
		return newObj;
	}
}
