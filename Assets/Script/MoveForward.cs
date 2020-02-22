using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

	private void Start()
	{
		Destroy(this.gameObject , 5);
	}
	void Update()
    {
		float posY = transform.localPosition.y + (1* Time.deltaTime);
		transform.localPosition = new Vector3(transform.localPosition.x, posY, transform.localPosition.z);
    }
}
