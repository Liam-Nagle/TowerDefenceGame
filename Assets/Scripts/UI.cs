using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
	private int spawnID = -1;
	public GameObject _towersUI;
	public GameObject _upgradesUI;
	private bool _towerSelected;
	private TowerSpawning towerSpawning;
	private List<Tower> towers = new List<Tower>();

	//Unity allocations
	public List<Image> towerImage;
	public Tilemap Placeable;
	public AudioSource audioSelect;


	private void Start()
	{
		DeselectTowers();
		_upgradesUI.SetActive(false);
		_towersUI.SetActive(true);
		towerSpawning = GetComponent<TowerSpawning>();
	}
	void Update()
	{
		if (spawnID != -1)
		{
			towerSpawning.DetectSpawnPoint();
		}

		if (Input.GetMouseButtonDown(0))
		{
			//get the world space position of the mouse
			var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//get the position of the cell in the tilemap
			var cellPosDefault = Placeable.WorldToCell(mousePos);
			//get the center position of the cell
			var cellPosCentered = Placeable.GetCellCenterWorld(cellPosDefault);
            //check if the cell is eligible (collider)
			
			
			if(_towerSelected == true)
            {
				return;
            } else
            {
				for (int i = 0; i < towers.Count; i++)
				{
					towers[i].Deselect();
				}
				//EventSystem.current.currentSelectedGameObject
				foreach (var tower in towers)
				{
					if (cellPosCentered == tower.GetTowerPosition())
					{
						OpenUpgradeUI();
						tower.Select();
						break;
					}
					else
					{
						OpenTowerUI();
					}
				}
			}
        }

        if (Input.GetMouseButtonDown(1))
		{
			DeselectTowers();
			OpenTowerUI();
			for (int i = 0; i < towers.Count; i++)
			{
				towers[i].Deselect();
			}
		}
	}
	public void SelectTower(int id)
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
			towerImage[spawnID].color = Color.white;
			audioSelect.Play(0);
		}
	}

	public void DeselectTowers()
	{
		OpenTowerUI();
		spawnID = -1;
		_towerSelected = false;
		foreach (var t in towerImage)
		{
			t.color = new Color(0.5f, 0.5f, 0.5f);
		}
	}

	public int GetSpawnID()
    {
		return spawnID;
    }

	public void OpenUpgradeUI()
    {
		_towersUI.SetActive(false);
		_upgradesUI.SetActive(true);

    }
	public void OpenTowerUI()
	{
		_towersUI.SetActive(true);
		_upgradesUI.SetActive(false);
	}

	public void SetTowers(Tower tower)
    {
		towers.Add(tower);
    }
}
