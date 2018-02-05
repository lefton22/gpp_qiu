using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEnemy : MonoBehaviour {

	static public List <GameObject> monsters = new List<GameObject>();

	void Start () 
	{
		monsters.AddRange(GameObject.FindGameObjectsWithTag("monster1"));
		monsters.AddRange(GameObject.FindGameObjectsWithTag("monster2"));
		
	}

	void Update () {
		
	}
}
