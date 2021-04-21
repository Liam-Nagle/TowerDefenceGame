using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
	//list of towers(prefabs) that will instantiate
	public List<Tower> towersPrefabs;
	//Transform of the spawning towers(Root Object)
	public Transform spawnTowerRoot;
	//list of towers (UI)
	public List<Image> towers;
	//id of tower to spawn	
	int spawnID = -1;
	//Spawn Tilemap
	public Tilemap Placeable;
	private static GameObject _towersUI;
	private static GameObject _upgradesUI;
	private static List<Vector3> _towerPositions = new List<Vector3>();
	private static bool _towerSelected;

	public object GameManager { get; private set; }

    private void Start()
	{
		DeselectTowers();
		_towersUI = GameObject.Find("UI/Right Menu/Towers");
		_upgradesUI = GameObject.Find("UI/Right Menu/Upgrades");
		_upgradesUI.SetActive(false);
		_towersUI.SetActive(true);
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

		//Detect when mouse is click (first touch clicked)
		if (Input.GetMouseButtonDown(1))
		{
			DeselectTowers();
		}
	}

	void SpawnTower(Vector3 position)
	{
		Tower tower = Instantiate(towersPrefabs[spawnID], spawnTowerRoot);
		tower.transform.position = position;
		_towerPositions.Add(position);
	}
	private void SelectTower(int id)
	{
		if (spawnID == id)
		{
			DeselectTowers();
		}
		else
		{
			DeselectTowers();
			_towerSelected = true;
			//Set the spawnID
			spawnID = id;
			//Highlight the tower
			towers[spawnID].color = Color.white;
		}
	}

	public void DeselectTowers()
	{
		spawnID = -1;
		_towerSelected = false;
		foreach (var t in towers)
		{
			t.color = new Color(0.5f, 0.5f, 0.5f);
		}
	}

	public static List<Vector3> GetTowerPosistions()
	{
		return _towerPositions;
	}

	public static bool GetIfTowerSelected()
    {
		return _towerSelected;
    }

	public static void OpenUpgradeUI()
    {
		_towersUI.SetActive(false);
		_upgradesUI.SetActive(true);
    }
	public static void OpenTowerUI()
	{
		_towersUI.SetActive(true);
		_upgradesUI.SetActive(false);
	}
}
