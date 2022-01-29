using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("References")]
	[SerializeField] Rigidbody2D rigidbody;
	[Header("Attributes")]
	[SerializeField] float speed = 5f;

	Vector2 movement;
	public Camera cam;
	Vector2 mousePos;

	// Update is called once per frame
	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		cam.ScreenToWorldPoint(Input.mousePosition);
		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
	}

	void FixedUpdate()
	{
		rigidbody.MovePosition(rigidbody.position + movement * speed * Time.fixedDeltaTime);
		Vector2 lookDir = mousePos - rigidbody.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
		rigidbody.rotation = angle;

	}

}
