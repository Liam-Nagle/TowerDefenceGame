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
    //Get range sprite
    private SpriteRenderer _rangeIndicator;
    private Tilemap _Placeable;


    // Start is called before the first frame update
    void Start()
    {
        _Placeable = GameObject.Find("Grid/Placeable").GetComponent<Tilemap>();
        _rangeIndicator = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _rangeIndicator.transform.localScale = new Vector2(range, range);
    }

    // Update is called once per frame  
    void Update()
    {
        //Detect when mouse is click (first touch clicked)
        if (Input.GetMouseButtonDown(0))
        {
            //get the world space position of the mouse
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //get the position of the cell in the tilemap
            var cellPosDefault = _Placeable.WorldToCell(mousePos);
            //get the center position of the cell
            var cellPosCentered = _Placeable.GetCellCenterWorld(cellPosDefault);
            //check if the cell is eligible (collider)
            
            if(!UI.GetTowerPosistions().Contains(cellPosCentered))
            {
                UI.OpenTowerUI();
            } else if (UI.GetTowerPosistions().Contains(cellPosCentered) && UI.GetIfTowerSelected() == false)
            {
                UI.OpenUpgradeUI();
                Debug.Log("Tower Selected Is False");
            } else if (UI.GetTowerPosistions().Contains(cellPosCentered) && UI.GetIfTowerSelected() == true)
            {
                UI.OpenTowerUI();
                Debug.Log("Tower Selected Is True");
            }
        }
    }

}
