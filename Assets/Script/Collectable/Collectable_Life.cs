using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Life : CollectableBase, ICollectable
{
    private int _healthAmount = 40;

    private void Start()
    {
        SetCollectable(this);
    }
    public void ExecuteCollectableEffect()
    {
        PlayerController playerController = GetPlayerControler();

        if (playerController != null)
        {
            IHealth playerHealth = playerController.GetPlayerHealth();
            if(playerHealth != null)
            {
                playerHealth.AddHealth(_healthAmount);
            }
        }
    }
}
