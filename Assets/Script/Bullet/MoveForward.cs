using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
	public Rigidbody2D rb;

	private void Start()
	{
		Destroy(this.gameObject , 5);
		//Invoke("MadeCanMove",1.0f);
		rb.velocity = transform.right * 10.0f;
	}
	
}
