using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatorHelper : MonoBehaviour {

	public static InstantiatorHelper instance;
	private void Awake()
	{
		if (instance == null)
			instance = this;
	}
	[SerializeField] private  GameObject primaryParentObj;
	public   GameObject InstantiateObject(GameObject obj, GameObject parentObj)
	{
		GameObject newObj = Instantiate(obj, parentObj.transform.position, parentObj.transform.rotation);
		newObj.transform.parent = primaryParentObj.transform;
		return newObj;
	}
}
