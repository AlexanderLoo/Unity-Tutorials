using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
	
	public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour {

	private Rigidbody _rb;
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	private AudioSource _audio;

	void Start(){

		_rb = GetComponent<Rigidbody> ();
		_audio = GetComponent<AudioSource> ();
	}

	void Update(){

		if(Input.GetButton("Fire1") && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			_audio.Play ();
		Instantiate (shot,shotSpawn.position,shotSpawn.rotation);
		}
	}

	void FixedUpdate(){

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		_rb.velocity = movement * speed;

		_rb.position = new Vector3 (
			Mathf.Clamp (_rb.position.x, boundary.xMin, boundary.xMax),
			0,
			Mathf.Clamp (_rb.position.z, boundary.zMin, boundary.zMax)
		);
		_rb.rotation = Quaternion.Euler(0, 0, _rb.velocity.x * -tilt);
	}
}
