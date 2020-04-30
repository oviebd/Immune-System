using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private Rigidbody2D _rb;
	[SerializeField] private float _speed = 10.0f;

    private void OnEnable()
    {
		if (GetRigidbody() != null)
			GetRigidbody().velocity = transform.right * _speed;
	}

    private Rigidbody2D GetRigidbody()
    {
        if(_rb == null)
			_rb = GetComponent<Rigidbody2D>();
		return _rb;
	}

}
