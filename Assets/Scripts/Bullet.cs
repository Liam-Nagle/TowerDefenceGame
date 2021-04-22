using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    private Enemy targetEnemy;
    private int towerDamage;

    public float speed = 70f;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    public void SetEnemy(Enemy enemy)
    {
        targetEnemy = enemy;
    }

    public void SetTowerDamage(int _towerDamage)
    {
        towerDamage = _towerDamage;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Destroy(gameObject);
        targetEnemy.TakeDamage(towerDamage);
    }
}
