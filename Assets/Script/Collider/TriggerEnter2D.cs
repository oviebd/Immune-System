using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter2D : MonoBehaviour
{
	[SerializeField] private LayerMask layerMask = new LayerMask();
	void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log("Trigger enter  " + collision.gameObject.name);
		if ((layerMask.value & 1 << collision.gameObject.layer) != 0)
		{
			IColliderEnter collidable = this.gameObject.GetComponent<IColliderEnter>();
			if (collidable != null)
				collidable.onCollide(collision.gameObject);
		}
	}
}
