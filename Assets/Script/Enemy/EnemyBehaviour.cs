using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject playerObj;
    [SerializeField] private GameObject graphicsObj;

    private void Start()
    {
        graphicsObj.SetActive (false);
        SearchForPlayer();
    }


    void SearchForPlayer()
    {
        ShipController controller = FindObjectOfType<ShipController>();

        if (controller != null) 
        {
            graphicsObj.SetActive(true);

            Transform targetTransform = controller.gameObject.transform;
            IMove[] moves = gameObject.GetComponents<IMove>();

            for( int i =0; i<moves.Length;i++)
            {
                moves[i].Setup(targetTransform);
            }
        }
    }

    
}
