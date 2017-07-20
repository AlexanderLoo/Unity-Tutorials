using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	private Rigidbody _rb;
	public float speed;

	void Start(){

		_rb = GetComponent<Rigidbody> ();
		_rb.velocity = transform.forward * speed;

	}
}
