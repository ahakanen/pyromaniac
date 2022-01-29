using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("References")]
	[SerializeField] Rigidbody2D rigidbody;
	[Header("Attributes")]
	[SerializeField] float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
		if (rigidbody == null)
		{
			rigidbody = GetComponent<Rigidbody2D>();
		}
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 direction;
		direction = Vector2.zero;
		direction.x = Input.GetAxis("Horizontal");
		direction.y = Input.GetAxis("Vertical");
		if (direction.magnitude > 0.1f)
		{
			rigidbody.velocity = direction.normalized * speed * Time.deltaTime;
		}
		else
		{
			rigidbody.velocity = Vector2.zero;
		}
	}
}