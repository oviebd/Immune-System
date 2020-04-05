using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUtility : MonoBehaviour
{
    private Slider _slider;
	private float _maxLimit = 100;
	private float _minLimit = 0;
	[SerializeField] private bool _isSLiderMoveForward = true;

	public void SetMaxLimit(float limit)
	{
		if (GetSlider() == null)
			return;
		_maxLimit = limit;
		_slider.maxValue = limit;
	}
    
	public void SetSliderValue(float value)
	{
		if (GetSlider() == null)
			return;
		float calValue = ((_slider.maxValue - _slider.minValue) / _slider.maxValue) * value;
		_slider.value = calValue;
	}

	private Slider GetSlider()
	{
		if (_slider == null)
			_slider = this.gameObject.GetComponent<Slider>();
		return _slider;
	}
	public void ResetData()
	{
		if (GetSlider() != null)
		{
			if(_isSLiderMoveForward)
				_slider.value = _minLimit;
			else
				_slider.value = _maxLimit;
		}
			

	}
}
