using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{

    private GunController _gunController;

    private void Awake()
    {
        PlayerUpdateController.onPlayerSystemUpdate += OnPlayerUpdateSystemSTatus;
    }
    private void OnDestroy()
    {
        PlayerUpdateController.onPlayerSystemUpdate -= OnPlayerUpdateSystemSTatus;
    }

    void Start()
    {
        _gunController = this.gameObject.GetComponent<GunController>();
    }

    void OnPlayerUpdateSystemSTatus(GameEnum.UpgradeType upgradeType)
    {
        if (_gunController == null)
            return;

        switch (upgradeType)
        {
            case GameEnum.UpgradeType.AddGun:
                _gunController.AddGun();
                break;
            case GameEnum.UpgradeType.RemoveGun:
                _gunController.RemoveGun();
                break;
        }
    }
}
