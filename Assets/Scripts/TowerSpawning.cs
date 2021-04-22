using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerSpawning : MonoBehaviour
{

    //list of towers(prefabs) that will instantiate
    public List<Tower> towersPrefabs;
    //Transform of the spawning towers(Root Object)
    public Transform spawnTowerRoot;
    //Spawn Tilemap
    public Tilemap Placeable;
    private UI ui;
    private static int _towerID = 0;

    // Start is called before the first frame update
    void Start()
    {
        ui = GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void DetectSpawnPoint()
	{
        //Detect when mouse is click (first touch clicked)
        if (Input.GetMouseButtonDown(0))
        {
            //get the world space position of the mouse
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //get the position of the cell in the tilemap
            var cellPosDefault = Placeable.WorldToCell(mousePos);
            //get the center position of the cell
            var cellPosCentered = Placeable.GetCellCenterWorld(cellPosDefault);
            //check if the cell is eligible (collider)
            if (Placeable.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                //spawn the tower
                SpawnTower(cellPosCentered);
                //Disable the collider
                Placeable.SetColliderType(cellPosDefault, Tile.ColliderType.None);
            }
        }
	}

	void SpawnTower(Vector3 position)
	{
		_towerID++;
		Tower tower = Instantiate(towersPrefabs[ui.GetSpawnID()], spawnTowerRoot);
		tower.transform.position = position;
		tower.SetTowerID(_towerID);
        tower.SetTowerPosition(position);
        ui.SetTowers(tower);
	}
}
