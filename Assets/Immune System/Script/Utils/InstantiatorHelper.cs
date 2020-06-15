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
	[SerializeField] private GameObject primaryParentObj;
	[SerializeField] private GameObject canvasParentObj;

    public GameObject InstantiateObject(GameObject obj, GameObject parentObj)
	{
		GameObject newObj = Instantiate(obj, parentObj.transform.position, parentObj.transform.rotation);
		newObj.transform.parent = primaryParentObj.transform;
		return newObj;
	}
	
	public GameObject InstantiateObject(GameObject obj)
	{
		GameObject newObj = Instantiate(obj);
		return newObj;
	}



	public GameObject InstantiateCanvasUIObject(GameObject obj)
	{
		GameObject newObj = Instantiate(obj, canvasParentObj.transform.position, canvasParentObj.transform.rotation);
		newObj.transform.parent = canvasParentObj.transform;
		return newObj;
	}

	public GameObject InstantiateCanvasUIObject(GameObject obj,GameObject parent)
	{
		GameObject newObj = Instantiate(obj, canvasParentObj.transform.position, parent.transform.rotation);
		newObj.transform.parent = parent.transform;
		newObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		newObj.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
		return newObj;
	}
}
