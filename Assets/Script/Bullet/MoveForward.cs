using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private Rigidbody2D _rb;
	[SerializeField] private float _speed = 10.0f;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();

        if(_rb!=null)
			_rb.velocity = transform.right * _speed;
	}
	
}
