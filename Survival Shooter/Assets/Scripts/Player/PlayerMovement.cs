﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Animator anim;
	private Rigidbody playerRigidbody;

	public float speed = 6f;

	private Vector3 movement;
	private int floorMask;
	private float camRayLength = 100f;

	void Awake(){

		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){

		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		Move (h, v);
		Turnig ();
		Animating (h, v);
	}

	void Move(float h, float v){

		movement.Set (h, 0, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Turnig(){

		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {

			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0;

			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidbody.MoveRotation (newRotation);
		}
	}

	void Animating(float h, float v){

		bool walking = h != 0 || v != 0;
		anim.SetBool ("IsWalking", walking);
	}
}
