using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private float explosionRadius = 0f;
    [SerializeField] private float bulletSpeed = 70f;
    [SerializeField] private int damage = 50;


    public void Seek(Transform _target)
    {
        target = _target;
    }



	
	// Update is called once per frame
	void Update ()
    {
	    if(target == null)
        {
            
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;

        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);



	}


    void HitTarget()
    {
        GameObject effectInst = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInst, 5.0f);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }


        Destroy(gameObject);
        //Debug.Log("WE GOT A HITT BABY!");
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Destroy(gameObject);

                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform Enemy)
    {
        EnemyAttributes e = Enemy.GetComponent<EnemyAttributes>();
        if (e != null)
        {
            Destroy(gameObject);

            e.EnemyTakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
