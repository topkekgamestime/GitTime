using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDManamegent : MonoBehaviour {

	[Range(0,100)]
	public int x;
	[Range(0,100)]
	public int y;
	[Range(0,100)]
	public int z;
	[Range(0,9999999)]
	public int money = 0;
	public Text kazoos;
	public int caos;

	public Slider Fofo;
	public Slider Humor;
	public Slider Treta;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Fofo.value = x;
		Humor.value = y;
		Treta.value = z;
		kazoos.text = money.ToString();

		if(Input.GetKeyDown("escape"))
			{
			SceneManager.LoadScene (3);
				Debug.Log("Pause");

			}
	}
}
