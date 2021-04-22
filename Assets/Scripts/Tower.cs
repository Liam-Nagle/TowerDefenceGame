using UnityEngine;

public class Tower : MonoBehaviour
{

    [Header("Attributes")]
    //Maximum attack range
    public int range;
    //Damage to enemy on collision
    public int towerDamage;
    public float fireRate = 1f;

    [Header("Unity Setup Fields")]

    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;
    private float fireCountdown = 0f;

    private Vector3 _towerPosition;
    //Get range sprite
    private SpriteRenderer _rangeSpriteRenderer;
    private int _towerID;
    private Transform _target;
    private Enemy _targetEnemy;

    public GameObject bulletPrefab;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        _rangeSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _rangeSpriteRenderer.transform.localScale = new Vector3(range, range);
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                _target = nearestEnemy.transform;
                _targetEnemy = nearestEnemy.GetComponent<Enemy>();
            }
            else
            {
                _target = null;
            }
        }
    }


    // Update is called once per frame  
    void Update()
    {
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void LockOnTarget()
    {
        Vector3 dir = _target.position - transform.position;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.SetEnemy(_targetEnemy);
        bullet.SetTowerDamage(towerDamage);

        if (bullet != null)
        {
            bullet.SetTarget(_target);
        }
    }


    public void Select()
    {
        _rangeSpriteRenderer.enabled = true;
    }

    public void Deselect()
    {
        _rangeSpriteRenderer.enabled = false;
    }

    public int GetTowerID()
    {
        return _towerID;
    }

    public void SetTowerID(int id)
    {
        _towerID = id;
    }

    public Vector3 GetTowerPosition()
    {
        return _towerPosition;
    }

    public void SetTowerPosition(Vector3 towerPosition)
    {
        _towerPosition = towerPosition;
    }

}
