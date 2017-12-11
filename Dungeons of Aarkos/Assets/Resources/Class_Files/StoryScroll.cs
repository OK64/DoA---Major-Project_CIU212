using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryScroll:MonoBehaviour
{
	private int index;
	private string[] textScript;
	private bool onTransition;
	private bool fadeSwitch;
	private float transitionTimer;
	public Text textLine;

	void Start()
	{
		index = 0;
		textScript = new string[12];
		textScript[index++] = "There was once a man...";
		textScript[index++] = "That man was you.";
		textScript[index++] = "You were merely minding your own business";
		textScript[index++] = "...when suddenly...";
		textScript[index++] = "The lord of Dungeons arrives...";
		textScript[index++] = "          AARKOS          ";
		textScript[index++] = "From the tip of his bladed staff...";
		textScript[index++] = "a dark light strikes deep into your soul.";
		textScript[index++] = "Your soul was captured!";
		textScript[index++] = "Your soul must be retrieved.";
		textScript[index++] = "You reach for your trusty weapon of choice...";
		textScript[index++] = "JOURNEY BEGIN";
		index = 0;

		textLine.text = "";
		textLine.color = new Color(textLine.color.r, textLine.color.g, textLine.color.b, 0);

		onTransition = true;
		fadeSwitch = false;
		transitionTimer = 1;
		GameObject.Find("Player").GetComponent<PlayerMovement>().active = false;
	}

	void Update()
	{
		if(index-1 < textScript.Length)
		{
			if(transitionTimer > 0 && !onTransition)
			{
				transitionTimer -= Time.deltaTime;
				if(transitionTimer <= 0)
				{
					transitionTimer = 0;
					onTransition = true;
				}
			}else if(onTransition){
				fadeTransition();
			}
		}
		
		if(index == textScript.Length && fadeSwitch)
		{
			gameObject.GetComponent<Image>().color -= new Color(0, 0, 0, 0.25f*Time.deltaTime);
			GameObject.Find("Player").GetComponent<PlayerMovement>().active = true;
			if(gameObject.GetComponent<Image>().color.a <= 0)
			{
				gameObject.SetActive(false);
			}
		}

		if(Input.GetKey(KeyCode.KeypadEnter))
		{
			transitionTimer = 0;
			onTransition = true;
			if(Input.GetKey(KeyCode.LeftShift))
			{
				GameObject.Find("Player").GetComponent<PlayerMovement>().active = true;
				gameObject.SetActive(false);
			}
		}
	}

	public void fadeTransition()
	{
		if(fadeSwitch && textLine.color.a > 0)
		{
			textLine.color -= new Color(0, 0, 0, 1*Time.deltaTime);
			if(textLine.color.a <= 0 && index < textScript.Length)
			{
				textLine.text = textScript[index++];
				transitionTimer += textLine.text.ToCharArray().Length*0.075f;
				fadeSwitch = false;
			}
		}else if(!fadeSwitch && textLine.color.a < 1){
			textLine.color += new Color(0, 0, 0, 1*Time.deltaTime);
			if(textLine.color.a >= 1)
			{
				textLine.color = new Color(textLine.color.r, textLine.color.g, textLine.color.b, 1);
				fadeSwitch = true;
				onTransition = false;
			}
		}
	}
}
