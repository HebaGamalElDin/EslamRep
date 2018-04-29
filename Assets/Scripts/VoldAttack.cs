using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class VoldAttack : MonoBehaviour {

	public float damage = 10f;
	public float range = 50f;
	public Transform fps;
	public RaycastHit hitinfo;
	Slider SHealth;
	[SerializeField] private Transform bulletGune;
	[SerializeField] private GameObject bulletprefap;
	Animator anime;
	//public ParticleSystem muzzleFlash;

	// Use this for initialization
	void Start () {
		Assert.IsNotNull(bulletprefap);
		Assert.IsNotNull(bulletGune);
	}

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position,fps.position) <= 10)
		{
			Debug.Log ("Eslam");
			shoot();
			fire_bullet();
		}

	}
	void shoot()
	{
		// muzzleFlash.Play();
		// RaycastHit hitinfo;

		if (Physics.Raycast(fps.transform.position,fps.transform.forward,out hitinfo,range))
		{

			if (hitinfo.distance <= range) {
				hitinfo.transform.SendMessage ("setAmount", damage, SendMessageOptions.DontRequireReceiver);	
			}

			Debug.Log(hitinfo.transform.name);
			Target_Script target = hitinfo.transform.GetComponent<Target_Script>();


		}
	}
	void fire_bullet()
	{
		GameObject fireball = Instantiate(bulletprefap,bulletGune.position,bulletGune.rotation) as GameObject;
		// fireball.GetComponent<Rigidbody>().velocity = fireball.transform.forward * 4;
		fireball.GetComponent<Rigidbody>().AddForce(fireball.transform.forward * 800);

		Destroy(fireball,3f);

	}


}
