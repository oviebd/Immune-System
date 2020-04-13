using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Schild : CollectableBase,ICollectable
{
    [SerializeField] private GameObject _schildObj;
    private void Start()
    {
        SetCollectable(this);
    }

    public void ExecuteCollectableEffect()
    {
        PlayerController playerController = GetPlayerControler();

        if (playerController != null)
        {
            GameObject schild = Instantiate(_schildObj, _schildObj.transform);
            schild.transform.parent = playerController.gameObject.transform;

            Destroy(schild,5.0f);
        }
    }
}
