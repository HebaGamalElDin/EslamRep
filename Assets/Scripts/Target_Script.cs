using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target_Script : MonoBehaviour {

	public float health=50f;
	public float amountn;
	Animator anime;
	float timer = 0f;
	bool dissapearEnemy = false;
	[SerializeField] private float dissaperaSpeed = 2f;
	private NavMeshAgent nav;  // This component is attached to a mobile character in the game to allow it to navigate the scene using the NavMesh.


	void Start(){
		anime = GetComponent<Animator> ();
		nav = GetComponent<NavMeshAgent> ();
	}

	void setAmount(float amount){
		amountn = amount;
	}

	void Update(){
		timer += Time.deltaTime;
		if (dissapearEnemy) {
			transform.Translate (-Vector3.up * dissaperaSpeed * Time.deltaTime);
		}
		take_Damage (amountn);
	}

	public void take_Damage(float amount)
	{
		health -= amount;
		if (health <= 0)
		{
			anime.Play ("Die");
			nav.SetDestination(nav.nextPosition);
			StartCoroutine (removeEnemy());
		}
	}

	IEnumerator removeEnemy (){
		yield return new WaitForSeconds (1.3f);
		dissapearEnemy = true;
		yield return new WaitForSeconds (0f);
		Destroy (gameObject);
	}	
}
