using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth1 : MonoBehaviour {

	[SerializeField] int startHealth = 10;
	[SerializeField] float timeSinceLasthit = 2f;

	private float timer = 0f;
	private CharacterController cr;
	private Animator anim;
	private int currentHealth;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		cr = GetComponent<CharacterController> ();
		currentHealth = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;	//Keep track of time

	}

	void OnTriggerEnter (Collider other)	// Whenever anything enter the collider this fn starts
	{
		if (timer >= timeSinceLasthit && !GameManager.instance.GameOver) {

			if (other.tag == "Weapon") {
				takeHit ();
				timer = 0;
			}
			
		}

	}

	void takeHit ()
	{
		if (currentHealth > 0) {
			GameManager.instance.PlayerHit (currentHealth);
			currentHealth -= 10;
		}

		if (currentHealth <= 0) {
			killPlayer ();
			Debug.Log ("Killed");
		}
	}

	void killPlayer ()
	{
		GameManager.instance.PlayerHit (currentHealth);
		cr.enabled = false;
	}
}
