using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderExit : MonoBehaviour {

	[SerializeField] private LayerMask layerMask = new LayerMask();

	private void OnCollisionExit2D(Collision2D collision)
	{
		if ((layerMask.value & 1 << collision.gameObject.layer) != 0)
		{
			Debug.Log("Collider Exit............................ ");
			IColliderExit collidable = this.gameObject.GetComponent<IColliderExit>();
			if (collidable != null)
				collidable.onColliderExit(collision);
		}
	}
}
