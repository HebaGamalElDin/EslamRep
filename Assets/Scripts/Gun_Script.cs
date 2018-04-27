
using UnityEngine;
using UnityEngine.Assertions;
public class Gun_Script : MonoBehaviour {

    public float damage = 10f;
    public float range = 20f;
    public Camera fps;
    [SerializeField] private Transform bulletGune;
    [SerializeField] private GameObject bulletprefap;
    //public ParticleSystem muzzleFlash;

	// Use this for initialization
	void Start () {
        Assert.IsNotNull(bulletprefap);
        Assert.IsNotNull(bulletGune);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
           
            shoot();
            fire_bullet();
        }

	}
    void shoot()
    {
       // muzzleFlash.Play();
        RaycastHit hitinfo;
        
        if (Physics.Raycast(fps.transform.position,fps.transform.forward,out hitinfo,range))
        {
             
            if (hitinfo.distance <= range)
                hitinfo.transform.SendMessage("take_Damage", damage, SendMessageOptions.DontRequireReceiver);
            Debug.Log(hitinfo.transform.name);
            Target_Script target = hitinfo.transform.GetComponent<Target_Script>();
            //if (target != null)
           // {
            //    target.take_Damage(damage);
            //}

        }
    }
    void fire_bullet()
    {
        GameObject fireball = Instantiate(bulletprefap,bulletGune.position,bulletGune.rotation) as GameObject;
        // fireball.GetComponent<Rigidbody>().velocity = fireball.transform.forward * 4;
        fireball.GetComponent<Rigidbody>().AddForce(fireball.transform.forward * 1000);
        Destroy(fireball,3f);
    }
    
    
}
