using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class EnemyMove : MonoBehaviour {

	[SerializeField] Transform player;		// Reference to the player to be followed
	private NavMeshAgent nav;				// This component is attached to a mobile character in the game to allow it to navigate the scene using the NavMesh.
	private Animator anim;

	// Make sure this is not null when we start the game
	void Awake ()
	{
		Assert.IsNotNull (player);
	}

	// Use this for initialization
	void Start () {
		
		// Get a References to the animation and the navmesh
		anim = GetComponent<Animator> ();
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {

		// AI of the Enemeis
		nav.SetDestination(player.position);	// Making the enemies following the player


	}
}
