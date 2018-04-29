using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine;

public class bull : MonoBehaviour {
	// Use this for initialization
	Gun_Script Gun;
	Target_Script target;
	public Transform cube;

	void Start () {
		target = new Target_Script();
		Gun = new Gun_Script();
	}

	// Update is called once per frame
	void Update () {


		// cube.gameObject.GetComponent
		//  target.take_Damage(10);
	}


	public void OnCollisionEnter(Collision collision)
	{
		// You probably want a check here to make sure you're hitting a zombie
		// Note that this is not the best method for doing so.
		if (collision.gameObject.tag == "Cubs")
		{
			// this.Update();
			//collision.gameObject.AddComponent<Target_Script>().health=10 ;
			//Destroy(collision.gameObject);

		    collision.gameObject.transform.SendMessage("take_Damage", Gun.damage, SendMessageOptions.DontRequireReceiver);

			collision.gameObject.transform.SendMessage ("CollectHocruxes", Gun.damage, SendMessageOptions.DontRequireReceiver);	


			Debug.Log(Gun.damage);

			//collision.gameObject.AddComponent<Target_Script>().Update();
			//target.take_Damage(10);
			Destroy(this.gameObject);
			//Destroy(gameObject);

		}
	}

}
