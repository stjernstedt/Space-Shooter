using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
	public GameObject healthBar;
	public Transform healthBarsParent;
	public Text uiPoints;
	GameObject player;
	int points = 0;

	// Use this for initialization
	void Start()
	{
		//healthBarsParent = GameObject.Find("HealthBarsParent").transform;
		player = GameObject.FindGameObjectWithTag("Player");
		UpdateUI();
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

}