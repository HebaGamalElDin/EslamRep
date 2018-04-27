using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Target_Script : MonoBehaviour {

    public float health=50f;

    public void take_Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            die();
        }
    }
    void die()
    {
        Destroy(gameObject);
    }
	
}
