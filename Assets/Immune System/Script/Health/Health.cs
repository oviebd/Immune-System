using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealth 
{
    [SerializeField] private int _totalHealth = 100;
    [Header("If this component is Player then made it true.")]
    [SerializeField] private bool _isItPlayerHealth = false; // Only Player Health Will Update UI
 
    private int _currentHealth;
	public delegate void HealthValueChanged(int currentHealth, int totalHealth);
	public static event HealthValueChanged onHealthValueChanged;

	private void Awake()
    {
        _currentHealth = _totalHealth;
    }

    public void AddHealth(int amount)
    {
        SetHealthAmount(_currentHealth + amount);
    }

    public bool IsDie()
    {
        if (_currentHealth <= 0)
            return true;
        else
            return false;
    }

    public int GetCurrentHealthAmount()
    {
        return _currentHealth;
    }

    public void ReduceHealth(int amount)
    {
        SetHealthAmount(_currentHealth - amount);
    }
    public int GetMaxHealthAmount()
    {
        return _totalHealth;
    }

    public void SetHealthAmount(int amount)
    {
        _currentHealth = amount;

		if (_currentHealth < 0)
            _currentHealth = 0;
        if (_currentHealth > _totalHealth)
            _currentHealth = _totalHealth;

		if (_isItPlayerHealth)
			onHealthValueChanged(_currentHealth,_totalHealth);
	}

    public int GetTotalHealth()
    {
        return _totalHealth;
    }
}

