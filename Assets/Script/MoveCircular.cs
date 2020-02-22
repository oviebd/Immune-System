using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCircular : MonoBehaviour
{
	float rotationSpeed = 10.0f;
	bool isButtonPressed = false;

	public GameObject _bulletObj;
	public GameObject _parentObj;
    void Start()
    {
	
	}

    void Update()
    {
		if (Input.GetKey(KeyCode.S))
		{
		    GameObject bulletObj =	InstantiatorHelper.InstantiateObject(_bulletObj, _parentObj);
			//StartCoroutine(madeParentNull(bulletObj));
		}

	}

	IEnumerator madeParentNull(GameObject bullet)
	{
		yield return new WaitForSeconds(0.5f);
		bullet.transform.parent = null;
	}

	public void ButtonPressedDown()
	{
		isButtonPressed = true;
	}
	public void ButtonPressedUp()
	{
		isButtonPressed = false;
	}


}
