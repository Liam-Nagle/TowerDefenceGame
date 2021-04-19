using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private Vector3 _towerPosition;
    private Tilemap _placeable;
    private bool towerSelected;


    // Start is called before the first frame update
    void Start()
    {
        _towerPosition = GetComponent<Transform>().position;
        _rangeIndicator = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _rangeIndicator.transform.localScale = new Vector2(range, range);
        _rangeIndicator.enabled = false;
        _placeable = GameObject.Find("Grid/Placeable").GetComponent<Tilemap>();
    }

    // Update is called once per frame  
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //get the world space position of the mouse
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //get the position of the cell in the tilemap
            var cellPosDefault = _placeable.WorldToCell(mousePos);
            //get the center position of the cell
            var cellPosCentered = _placeable.GetCellCenterWorld(cellPosDefault);

            if (towerSelected == false)
            {
                if (cellPosCentered == _towerPosition)
                {
                    OpenTowerUpgradeUI();
                    towerSelected = true;
                }

                //Tower Position Array that holds ALL tower positions XYZ. Then in HERE. Check if the tile your clicking on IS listed in that array (for loop) then OPEN THE MENU
                //if it isn't then it can do something else.

            } else if ((towerSelected == true) && (cellPosCentered == _towerPosition))
            {
                return;
            } 
        }

        //    if (Input.GetMouseButtonDown(0))
        //{
        //    //get the world space position of the mouse
        //    var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    //get the position of the cell in the tilemap
        //    var cellPosDefault = _placeable.WorldToCell(mousePos);
        //    //get the center position of the cell
        //    var cellPosCentered = _placeable.GetCellCenterWorld(cellPosDefault);

        //    if(cellPosCentered == _towerPosition)
        //    {
        //        OpenTowerUpgradeUI();
        //    } else
        //    {
        //        CloseTowerUpgradeUI();
        //    }
        //}

        //if (Input.GetMouseButtonDown(1))
        //{
        //    CloseTowerUpgradeUI();
        //}
    }

    void OpenTowerUpgradeUI()
    {
        _rangeIndicator.enabled = true;
        UI.SwitchMenu();
    }

    void CloseTowerUpgradeUI()
    {

        _rangeIndicator.enabled = false;
        UI.SwitchMenu();
    }

}
