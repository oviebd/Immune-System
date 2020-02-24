using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject playerObj;
    float speed = 1.0f;

	private void Awake()
	{
		ShipController controller = FindObjectOfType<ShipController>();
		if (controller != null)
		{
			playerObj = controller.gameObject;
		}
	}

	void Start()
    {
        // transform.LookAt(playerObj.transform);
        look();
    }
    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerObj.transform.position, step);
    }

    void look()
    {
        Vector3 dir = playerObj.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
