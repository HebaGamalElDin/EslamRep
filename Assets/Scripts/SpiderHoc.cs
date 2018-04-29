using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpiderHoc : MonoBehaviour {

	public float health=50f;
	public Slider Hel;
	public Text NoH;
	private static int Counter = 5;

	public void CollectHocruxes(float amount)
	{
		health -= amount;
		if (health <= 0) {
			die ();
			NoH.text = Counter.ToString (); 
			if (Hel.value != 0){
				Hel.value -= (float)0.1;
			}
		}
	}

	void die()
	{
		Destroy (gameObject);
	}

}
