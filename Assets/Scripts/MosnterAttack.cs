using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MosnterAttack : MonoBehaviour {
    public float damage = 10f;
    public float range;
    public GameObject fps;
    [SerializeField] private Transform bulletGuneMons;
    [SerializeField] private GameObject bulletMons;
    public Transform firstPerson;
    //public ParticleSystem muzzleFlash;

    // Use this for initialization
    void Start()
    {
        damage = 10f;
        range = 50f;
        Assert.IsNotNull(bulletMons);
        Assert.IsNotNull(bulletGuneMons);
    }

    // Update is called once per frame
    void Update()
    {
		RotateTowards (firstPerson);
        Vector3 Direction = firstPerson.position - this.transform.position;
        float angle = Vector3.Angle(Direction, this.transform.forward);
        if (Vector3.Distance(firstPerson.position, this.transform.position) < 10f)
        {
        	FireArrow();

            //shootMons();
            // StartCoroutine( fire_bulletMons());

        }

    }
    void shootMons()
    {
        // muzzleFlash.Play();
        RaycastHit hitinfo;

        if (Physics.Raycast(fps.transform.position, fps.transform.forward, out hitinfo, range))
        {
            // fire_bullet();
            if (hitinfo.distance <= range)
                // hitinfo.transform.SendMessage("take_Damage", damage, SendMessageOptions.DontRequireReceiver);
                Debug.Log(hitinfo.transform.name);
            //Target_Script target = hitinfo.transform.GetComponent<Target_Script>();
            //if (target != null)
            // {
            //    target.take_Damage(damage);
            //}

        }
    }

    private void RotateTowards(Transform player)
    {

        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

    }

    public void FireArrow()
    {

        GameObject newArrow = Instantiate(bulletMons) as GameObject;
        newArrow.transform.position = bulletGuneMons.position;
        newArrow.transform.rotation = transform.rotation;
        newArrow.GetComponent<Rigidbody>().velocity = transform.forward * 50f;


    }





}
