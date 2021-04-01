using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yodo1.MAS;

public class YodoManager : MonoBehaviour
{

	public static YodoManager instance;

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}

	private void Start()
	{
		Yodo1U3dMas.InitializeSdk();
	}


}
