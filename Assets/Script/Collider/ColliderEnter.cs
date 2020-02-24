using UnityEngine;
using UnityEngine.Events;

public class ColliderEnter : MonoBehaviour {

    [SerializeField] private LayerMask layerMask = new LayerMask();

    private void OnCollisionEnter2D(Collision2D collision)
	{
		if ((layerMask.value & 1 << collision.gameObject.layer) !=0 )
		{
			//Debug.Log("Collider enter in if .......................... in " + collision.gameObject.name);
			IColliderEnter collidable = this.gameObject.GetComponent<IColliderEnter>();
			if (collidable != null)
				collidable.onCollide(collision.gameObject);
		}
	}
}
