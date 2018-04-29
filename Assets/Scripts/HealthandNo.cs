using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthandNo : MonoBehaviour {

	public float health=50f;
	public Slider Hel;
	public Text NoH;
	private static int Counter = 0;

	public void CollectHocruxes(float amount)
	{
		health -= amount;
		if (health <= 0) {
			die ();
			Counter++;
			NoH.text = Counter.ToString (); 
			if (Hel.value != 0){
				Hel.value -= (float)0.1;
				SetCountText ();
			}
		}
	}

	void die()
	{
		Destroy(gameObject);
	}

	void SetCountText()
	{
		if (Counter == 4)
		{
			SceneManager.LoadScene("Castle");
		}
	}

}
