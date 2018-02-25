using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class l3_enemyList : MonoBehaviour {

	static public List <GameObject> lmonster_wave1 = new List<GameObject>();

	float t;

	public string name_monster;

	void Start () 
	{
		lmonster_wave1.AddRange(GameObject.FindGameObjectsWithTag("monster1"));
		lmonster_wave1.AddRange(GameObject.FindGameObjectsWithTag("monster2"));

//		for (int i = 0; i < lmonster_wave1.Count; i++)
//			{
//			print(lmonster_wave1[i]);
//			}

	}

	void Update () 
	{
		if (Input.GetKey(KeyCode.K))
			{
			for (int i = 0; i < lmonster_wave1.Count; i++)
				{
				print(i);
				}
			}


		if (lmonster_wave1.Count == 0)
			{
			 generate();
			}
	}

//		void addToList()
//		{
//
//		}

//	public void update()
//		{
////				for (int i = 0; i < lmonster_wave1.Count; i++)
////					{
////
////					}
//		//print(lmonster_wave1[i].name);
////		foreach (Monsers m in lmonster_wave1)
////			{
////			m.update();
////			}
//		}
//		public abstract class Monsters
//		{
//		protected float x, y;
//
//			void update()
//			{
//			x += 1; y += 2;
//			}
//		}

	void print(int num)
		{
		print(lmonster_wave1[num].name);
		}


	void generate ()
		{


			GameObject monster = Instantiate(Resources.Load(name_monster)) as GameObject;
			monster.transform.position = gameObject.transform.position;
			monster.transform.SetParent(gameObject.transform);
			t = Time.time;
			//as_born.Play();
			monster.SendMessage("Born");
			//GameObject.Find("MainManager").SendMessage("addToList");

			if (!l3_enemyList.lmonster_wave1.Contains(monster))//add into the wave list
				{
				l3_enemyList.lmonster_wave1.Add(monster);
				}

		}

}
