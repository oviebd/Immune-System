using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour,IColliderEnter
{
    public GameObject playerObj;

    public delegate void TargetFound(Transform targetTransform);
	public static event TargetFound onTargetFound;

    private void Start()
    {
        SearchForPlayer();
    }


    void SearchForPlayer()
    {
        ShipController controller = FindObjectOfType<ShipController>();

        if (controller != null) 
        {
            Transform targetTransform = controller.gameObject.transform;
            IMove[] moves = gameObject.GetComponents<IMove>();

            for( int i =0; i<moves.Length;i++)
            {
                moves[i].Setup(targetTransform);
            }
        }
    }

    public void onCollide(GameObject collidedObject)
	{
		Destroy(collidedObject);
		Destroy(this.gameObject);
	}
}
