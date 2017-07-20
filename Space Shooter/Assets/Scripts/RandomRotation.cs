using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {

	public float tumble;
	private Rigidbody _rb;

	void Start(){

		_rb = GetComponent<Rigidbody> ();
		_rb.angularVelocity = Random.insideUnitSphere * tumble;

	}
		
}
