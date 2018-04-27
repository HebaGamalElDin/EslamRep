using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	[SerializeField] private float range = 3f;
	[SerializeField] private float timeBetweenAttacks = 1f;

	private Animator anim;
	private GameObject player;	// Reference to our player
	private bool playerInRange;
	private BoxCollider[] weaponColliders;	// Array because the tanker has 2 weapons


	// Use this for initialization
	void Start () {
		weaponColliders = GetComponentsInChildren<BoxCollider> ();	// Because the weapon is nested not a top level
		player = GameManager.instance.Player;	// Graping our player
		anim = GetComponent<Animator> ();
		StartCoroutine (attack ());	// Start a recursive routine of attack
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, player.transform.position) < range) {
			playerInRange = true;
		} else {
			playerInRange = false;
		}

		//print (playerInRange); 	// Testing
	}

	IEnumerator attack(){
		if (playerInRange && !GameManager.instance.GameOver) {	// Player in range and the game is still going
			anim.Play("Attack");
			yield return new WaitForSeconds (timeBetweenAttacks);
		}

		yield return null;
		StartCoroutine (attack ());	// Start a recursive routine of attack
	}
}
