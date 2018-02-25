using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using DG.Tweening;

	public abstract class Enemy : MonoBehaviour 
	{


	public AudioSource as_born;
	public AudioSource as_destroy_wall;
	public AudioSource as_destroy_bullet;
	public AudioClip ac_born;
	public AudioClip ac_destroy_wall;
	public AudioClip ac_destroy_bullet;



	//public bool isExisted;

//Constructor

//	public class Attributes
//		{
//		public int num = 1;
//		}
//	public Attributes atr1 = new Attributes();
//
//		void Start()
//		{
//		print("who am i : " + atr1.num);
//		}

//	public int num =2;
//
//	protected virtual void try1()
//		{
//		num = num + 1;
//		}
//	
		public void Start()
		{
		as_born = GameObject.Find("sound_born").GetComponent<AudioSource>();
		//as_born.clip = ac_born;
		as_destroy_bullet =  GameObject.Find("sound_destroy_bullet").GetComponent<AudioSource>();
		//as_destroy_bullet.clip = ac_destroy_bullet;
		as_destroy_wall = GameObject.Find("sound_destroy_wall").GetComponent<AudioSource>();
		//as_destroy_wall.clip = ac_destroy_wall;

		//isExisted = false;
		}

		public void Update()
		{

//// which enmey
//		switch (gameObject.tag)
//			{
//			case "monster1":
//				//print(gameObject.name + ": i'm 1");
//
//				Monster1Move();
//
//				break;
//
//			case "monster2":
//				//print(gameObject.name + ": i'm 2");
//				break;
//			}







		switch (gameObject.GetComponent<EnemyState>().collideWith)
			{ 
			//0 is null; 1 is wall; 2 is bullets; 3 is ship;
			case 1:
				//print("collide with wall");
				playSoundDestroy_wall();
				break;
			case 2:
				//print("collide with bullets");
				playSoundDestroy_bullet();
				break;
			case 3:
				//print("collide with ship");
				break;

			}
		if (gameObject != null)
			{
			MonsterMove(transform.position.x, transform.position.y, transform.position.z);
			playSoundBorn();
			}

		//is destory or not	
		switch (gameObject.GetComponent<EnemyState>().state)
			{
			case 0:
				playSoundBorn();
				//	print("born");
				break;

			case 1:

				break;
			case 2:
				Destroy();
				print("destrory");
				//				playSoundDestroy();
				break;
			}


		}


	protected void Destroy()
		{
		Destroy(gameObject);
		}


	protected virtual void MonsterMove(float moveX, float moveY, float moveZ )
		{
//		float y = transform.position.y;
//		transform.DOMove(new Vector3(transform.position.x, y-0.5f, transform.position.z),1f);
		transform.DOMove(new Vector3(moveX, moveY, moveZ),1f);

//		pos_this= gameObject.transform.position;
//		float step = speed * Time.deltaTime;
//		transform.position = Vector3.MoveTowards(new Vector3(moveX, moveY, moveZ), pos_this , step);
		}

	protected virtual void  playSoundDestroy_wall()
		{
		as_destroy_wall.Play();
		}
	protected virtual void  playSoundDestroy_bullet()
		{
		as_destroy_bullet.Play();
		}
	protected virtual void  playSoundBorn()
		{
		if (gameObject != null && gameObject.GetComponent<EnemyState>().isExisted)
			{

			as_born.Play();
			gameObject.GetComponent<EnemyState>().isExisted = false;
			}
		}

	}