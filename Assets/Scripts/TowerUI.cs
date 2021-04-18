using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
	//list of towers(prefabs) that will instantiate
	public List<GameObject> towersPrefabs;
	//Transform of the spawning towers(Root Object)
	public Transform spawnTowerRoot;
	//list of towers (UI)
	public List<Image> towersUI;
	//id of tower to spawn	
	int spawnID = -1;
	//Spawn Tilemap
	public Tilemap Placeable;

    private void Start()
    {
		DeselectTowers();
	}

    void Update()
	{
		if (spawnID != -1)
		{
			DetectSpawnPoint();
		}
	}

	bool CanSpawn()
	{
		if (spawnID == -1)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	void DetectSpawnPoint()
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
		GameObject tower = Instantiate(towersPrefabs[spawnID], spawnTowerRoot);
		tower.transform.position = position;
		DeselectTowers();
	}
	public void SelectTower(int id)
	{
		DeselectTowers();
		//Set the spawnID
		spawnID = id;
		//Highlight the tower
		towersUI[spawnID].color = Color.white;
	}

	public void DeselectTowers()
	{
		spawnID = -1;
		foreach (var t in towersUI)
		{
			t.color = new Color(0.5f, 0.5f, 0.5f);
		}
	}
}
