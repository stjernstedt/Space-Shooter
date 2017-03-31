using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
	int points;
	UIHandler uiHandler;

	// Use this for initialization
	void Start()
	{
		uiHandler = GetComponent<UIHandler>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void AddPoints(int points)
	{
		this.points += points;
		uiHandler.UpdateUI();
	}
}
