using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] private float moveSpeed = 10.0f;
	[SerializeField] private LayerMask layermask;

	private CharacterController charactercontroller;
	private Vector3 currentLookTarget = Vector3.zero;
	private Animator anim;

	// Use this for initialization
	void Start () {
		charactercontroller = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		charactercontroller.SimpleMove (moveDirection * moveSpeed);

		if (moveDirection == Vector3.zero) {
			anim.SetBool ("IsWalking", false);
		} else {
			anim.SetBool ("IsWalking", true);
		}

		if (Input.GetMouseButtonDown (0)) {
			anim.Play ("DoubleChop");
		}

		if (Input.GetMouseButtonDown (1)) {
			anim.Play ("SpinAttack");
		}
	}

	void FixedUpdate ()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		Debug.DrawRay (ray.origin, ray.direction * 500, Color.blue);

		if (Physics.Raycast (ray, out hit, 500, layermask, QueryTriggerInteraction.Ignore)) {
			if (hit.point != currentLookTarget) {
				currentLookTarget = hit.point;
			}

			Vector3 targetPosition = new Vector3 (hit.point.x, transform.position.y, hit.point.z);
			Quaternion rotation = Quaternion.LookRotation (targetPosition - transform.position);
			transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime * 10f);
		}
	}
}
