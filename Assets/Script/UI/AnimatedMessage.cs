using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedMessage : MonoBehaviour
{
	[SerializeField] private Text _txtMessage;
	private float _destroyTime = 3.0f;

	private void Start()
	{
		Destroy(this.gameObject, _destroyTime);
	}

	public void SetMessage(string message)
	{
		Debug.Log("Show Message .......... " + message);
		if (_txtMessage != null)
			_txtMessage.text = message;
	}

}
