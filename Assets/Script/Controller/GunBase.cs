using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour,IGun
{
	[SerializeField]private GameObject _bulletObj;
	[SerializeField]private GameObject _parentObj;
	public void InstantiateBullet()
	{
		GameObject bulletObj = InstantiatorHelper.InstantiateObject(_bulletObj, _parentObj);
	}
}
