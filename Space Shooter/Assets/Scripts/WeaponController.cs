using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	private AudioSource _audio;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;

	void Start(){

		_audio = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire(){

		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		_audio.Play ();
	}
}
