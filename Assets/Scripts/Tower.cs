using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    //Maximum attack range
    public int range;
    //Damage to enemy on collision
    public int towerDamage;
    //Get range sprite
    private SpriteRenderer _rangeIndicator;



    // Start is called before the first frame update
    void Start()
    {
        _rangeIndicator = GetComponent<SpriteRenderer>();
        _rangeIndicator.transform.localScale = new Vector2(range,range);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
