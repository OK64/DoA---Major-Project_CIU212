using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;
	public GameObject button5;
	public GameObject button6;
	public GameObject text1;
	public bool instructions = false;

	void Awake()
	{
		button4.SetActive(false);
		button5.SetActive(false);
		button6.SetActive(false);
		text1.SetActive (false);
	}
	// Use this for initialization
	void Start () {
		//button4.SetActive(false);
		//button5.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void characterClass()
	{
		button1.SetActive(false);
		button2.SetActive(false);
		button3.SetActive(false);
		//button4.SetActive(true);
		button5.SetActive(true);
	}

	public void Exit()
	{
		Application.Quit ();
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Scene");
	}

	public void Instructions()
	{
		if (instructions == false) 
		{
			Debug.Log ("instructions = false");
			button1.SetActive (false);
			button2.SetActive (false);
			button3.SetActive (false);
			button6.SetActive(true);
			text1.SetActive (true);
			instructions = true;
		}
		else
		{
			button1.SetActive (true);
			button2.SetActive (true);
			button3.SetActive (true);
			button6.SetActive(false);
			text1.SetActive (false);
			instructions = false;
		}
	}
}
