using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class TriggerEnter2D : MonoBehaviour
{
	[Header("Layers want to collided with")]
	[SerializeField] private LayerMask layerMask = new LayerMask();

	private Collider2D _collider;
	private void Start()
	{
		// Made Is Trigger True. Otherwise Unity can not detect Trigger Enter Event.
		_collider = this.gameObject.GetComponent<Collider2D>();
		if (_collider != null)
			_collider.isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if ((layerMask.value & 1 << collision.gameObject.layer) != 0)
		{
			IColliderEnter collidable = this.gameObject.GetComponent<IColliderEnter>();
			if (collidable != null)
				collidable.onCollide(collision.gameObject);
		}
	}
}
