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
	void Awake()
	{
		button4.SetActive(false);
		button5.SetActive(false);
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
}
