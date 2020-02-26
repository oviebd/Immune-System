using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourBase : MonoBehaviour, IColliderEnter
{
    [SerializeField] GameObject _playerObj;
    [SerializeField] private GameObject graphicsObj;

    private void Start()
    {
        SearchForPlayer();
    }


    void SearchForPlayer()
    {
        ShipController controller = FindObjectOfType<ShipController>();

        if (controller != null)
        {
            graphicsObj.SetActive(true);
            _playerObj = controller.gameObject;

            IENemyBehaviour behaviour = this.gameObject.GetComponent<IENemyBehaviour>();

            if (behaviour != null)
                behaviour.OnTargetFound(_playerObj);
        }
    }



    public void onCollide(GameObject collidedObject)
    {
        Destroy(collidedObject);
        Destroy(this.gameObject);
    }

}
