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
	private GameState _gameState;
	private bool _towerSelected;
	private TowerSpawning towerSpawning;
	private List<Tower> towers = new List<Tower>();
	private Transform _healthVector;
	private Transform _waveVector;


	//Unity allocations
	public List<Image> towerImage;
	public Tilemap Placeable;
	public AudioSource audioSelect;
	public GameObject[] numberSprites = new GameObject[10];
	public Transform spawnUIRoot;

	private void Start()
	{
		DeselectTowers();
		_upgradesUI.SetActive(false);
		_towersUI.SetActive(true);
		towerSpawning = GetComponent<TowerSpawning>();
		_gameState = GetComponent<GameState>();
		_healthVector = GameObject.Find("Health").GetComponent<Transform>();
		_waveVector = GameObject.Find("Wave").GetComponent<Transform>();
		UpdateHealth();
		UpdateWave();
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

	public void UpdateHealth()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("HealthUI"))
        {
			Destroy(item);
        }
		float pos = 2.8f;
		if (_gameState.health > 0)
        {
			int healthInt = _gameState.health;
            for (int i = 0; i < _gameState.health.ToString().Length; i++)
            {
				int digit = healthInt % 10;
				healthInt /= 10;
				Instantiate(numberSprites[digit], _healthVector.position + new Vector3(pos, 0, 0), _healthVector.rotation, spawnUIRoot);
				pos -= 0.8f;
			}

		} else
        {
			Instantiate(numberSprites[0], _healthVector.position + new Vector3(pos, 0, 0), _healthVector.rotation, spawnUIRoot);
		}
    }

	public void UpdateWave()
    {
		foreach (var item in GameObject.FindGameObjectsWithTag("WaveUI"))
		{
			Destroy(item);
		}
		float pos = 2.8f;
		if (_gameState.wave > 0)
		{
			int waveInt = _gameState.wave;
			for (int i = 0; i < _gameState.wave.ToString().Length; i++)
			{
				int digit = waveInt % 10;
				waveInt /= 10;
				Instantiate(numberSprites[digit], _waveVector.position + new Vector3(pos, 0, 0), _waveVector.rotation, spawnUIRoot);
				pos -= 0.8f;
			}

		}
		else
		{
			Instantiate(numberSprites[0], _waveVector.position + new Vector3(pos, 0, 0), _waveVector.rotation, spawnUIRoot);
		}
	}
}
