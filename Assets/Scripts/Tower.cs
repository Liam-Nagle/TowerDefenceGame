using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{

    //Maximum attack range
    public int range;
    //Damage to enemy on collision
    public int towerDamage;
    private Vector3 _towerPosition;
    //Get range sprite
    private SpriteRenderer _rangeSpriteRenderer;
    private int _towerID;



    // Start is called before the first frame update
    void Start()
    {
        _rangeSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame  
    void Update()
    {

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
