using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCircular : MonoBehaviour
{

	float rotateZ ;
    // Start is called before the first frame update
    void Start()
    {
		rotateZ = transform.rotation.z;

	}


	public void RotateClockWise()
	{

	}

	public void RotateAntiClockWIse()
	{

	}

    // Update is called once per frame
    void Update()
    {
		rotateZ = Mathf.Abs ( transform.rotation.z) + 10 * Time.deltaTime;
		Debug.Log(rotateZ);
		transform.Rotate(transform.rotation.x, transform.rotation.y, rotateZ);
	}
}
