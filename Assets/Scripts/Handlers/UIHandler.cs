using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
	public GameObject playerPrefab;
	public GameObject healthBar;
	public Transform healthBarsParent;
	public Text uiPoints;
	public GameObject gameOverPanel;
	public GameObject finalScorePanel;
	public GameObject retryButton;

	GameObject player;
	GameObject asteroidSpawner;
	int points = 0;

	// Use this for initialization
	void Start()
	{
		//healthBarsParent = GameObject.Find("HealthBarsParent").transform;
		player = GameObject.FindGameObjectWithTag("Player");
		asteroidSpawner = FindObjectOfType<AsteroidSpawner>().gameObject;
		UpdateUI();
		EventHandler.GameOverSubscribers += GameOver;
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	public void UpdateUI()
	{
		uiPoints.text = "" + points;
		int health = player.GetComponent<Health>().health;
		foreach (Transform bar in healthBarsParent)
		{
			Destroy(bar.gameObject);
		}
		for (int i = 0; i < health; i++)
		{
			GameObject bar = Instantiate(healthBar);
			bar.transform.SetParent(healthBarsParent);
			Color color = Color.Lerp(Color.green, Color.red, 1f / health);
			bar.GetComponent<Image>().color = color;
		}
	}

	public void AddPoints(int points)
	{
		this.points += points;
		UpdateUI();
	}

	void GameOver()
	{
		StartCoroutine(GameOverSequence());
	}

	IEnumerator GameOverSequence()
	{
		asteroidSpawner.SetActive(false);

		gameOverPanel.SetActive(true);
		yield return new WaitForSeconds(1);
		finalScorePanel.SetActive(true);
		finalScorePanel.GetComponentInChildren<Text>().text = "Score: " + points;
		yield return new WaitForSeconds(1);
		retryButton.SetActive(true);
	}

	public void NewGame()
	{
		points = 0;

		ObjectPool objectPool = FindObjectOfType<ObjectPool>();
		foreach (GameObject asteroid in objectPool.bigAsteroids)
		{
			if (asteroid.activeSelf)
				objectPool.ReturnObject(asteroid);
		}

		foreach (GameObject asteroid in objectPool.smallAsteroids)
		{
			if (asteroid.activeSelf)
				objectPool.ReturnObject(asteroid);
		}

		gameOverPanel.SetActive(false);
		finalScorePanel.SetActive(false);
		retryButton.SetActive(false);

		player = Instantiate(playerPrefab);
		asteroidSpawner.SetActive(true);

		UpdateUI();
	}

}