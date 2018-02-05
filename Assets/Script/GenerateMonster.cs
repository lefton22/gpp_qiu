using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMonster : MonoBehaviour {

	public string name_monster;

	float t;

	public AudioSource as_born;
	public AudioClip ac_born;

	void Start () 
	{
		t = 0f;
		as_born = GameObject.Find("sound_born").GetComponent<AudioSource>();
	}
	

	void Update () 
	{

		if (Time.time - t > 1f)
			{

			GameObject monster = Instantiate(Resources.Load(name_monster)) as GameObject;
			monster.transform.position = gameObject.transform.position;
			monster.transform.SetParent(gameObject.transform);
			t = Time.time;
			//as_born.Play();
			monster.SendMessage("Born");
			}
	}


}
