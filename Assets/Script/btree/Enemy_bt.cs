using BehaviorTree;
using UnityEngine;

public class Enemy_bt : MonoBehaviour
	{
	private Tree<Enemy_bt> _tree;
	[SerializeField] private GameObject _player;
	[SerializeField] private float _speed;
	[SerializeField] private float _visibilityRange;
	[SerializeField] private float _damagePerHit;
	[SerializeField] private float _distance;

	private const float MaxHealth = 10;
	[SerializeField] private float _health = MaxHealth;

//	public bool isPulse = false;
	public float t = 999f;
//	public int num = 0;
//	public bool StartPulse = false;

	public bool isHitByBullet = false;
	public bool isRecordTime = false;

	private void Start ()
		{
		// We define the tree and use a selector at the root to pick the high level behavior (i.e. fight, flight or idle)
		_tree = new Tree<Enemy_bt>(new Selector<Enemy_bt>(

			// (highest priority)
			// Flee Behavior

			new Sequence<Enemy_bt>( // We use a sequence here since this is effectively a checklist...

				new IsPlayerOutCircle(), // the player is in range...
				new Seek() // then run away
			),


			new Sequence<Enemy_bt>( // We use a sequence here since this is effectively a checklist...

				//new IsTimeOut(),
				new IsPlayerInCircle(), // the player is in range...
				new PreAttack() // then run away
			),

			new Sequence<Enemy_bt>( // We use a sequence here since this is effectively a checklist...

				new IsHit(), // the player is in range...
				new Attack() // then run away
			),

//			new Sequence<Enemy_bt>( // We use a sequence here since this is effectively a checklist...
//				// Sequences fail as soon as a child fails so they're a good way to check
//				// a bunch of conditions before doing something
//				new IsInDanger(), // If the enemy has taken a lot of damage AND...
//				new IsPlayerInRange(), // the player is in range...
//				new Flee() // then run away
//			),
//
//			// Fight Behavior
//			// If we don't need to run then fight...
//			new Sequence<Enemy_bt>( // Another sequence to check pre-conditions
//				new IsPlayerInRange(), // If the player is in range...
//				new Attack() // Attack
//			),

			// (lowest priority)
			// Idle behavior
			// The idle behavior is on the bottom of list so if everything else fails we'll end up here
			new Idle()
		));
		}

	private void Update ()
		{
		// Update the tree by passing it the context that it should use to drive its decisions/act on
		_tree.Update(this);
		// Draw a red circle around the enemy so we can see the detection radius
		DrawVisibilityRange();

//		var playerPos = _player.transform.position;
//		var enemyPos = transform.position;
//		Debug.Log ("dis: "  + Vector3.Distance(playerPos, enemyPos));

//		if (!isPulse && StartPulse)
//			{
//				if (Time.time - t > 2f && num < 6)
//					{
//					gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
//					num = num + 1;
//					t = Time.time;
//					}
//				if (Time.time - t > 0.5f && Time.time - t < 2f && num < 6)
//					{
//					gameObject.GetComponent<SpriteRenderer>().color = Color.black;
//					}
//
//			}
//		if (num == 6)
//			{
//			isPulse = true;
//			}
		//Debug.Log (isRecordTime);
		if (isRecordTime)
			{
			t = Time.time;
			Debug.Log("t: " + t);
			}
		}

	private void MoveTowardsPlayer()
		{
		var playerDirection = (_player.transform.position - transform.position).normalized;
		var body = GetComponent<Rigidbody2D>();
		body.AddForce(playerDirection * _speed, ForceMode2D.Impulse);
		}

	private void MoveAwayFromPlayer()
		{
		var fleeDirection = (transform.position - _player.transform.position).normalized;
		var body = GetComponent<Rigidbody2D>();
		body.AddForce(fleeDirection * _speed, ForceMode2D.Impulse);
		}

	private void SetColor(Color c)
		{
		gameObject.GetComponent<SpriteRenderer>().color = c;
		}

	private void RecordTime()
		{
		isRecordTime = true;
		}

	 void OnCollisionEnter2D(Collision2D coll)
		{
		//if (coll.gameObject.GetComponent<Player>() == null) return;
		_health = Mathf.Max(_health - _damagePerHit, 0);
		var body = GetComponent<Rigidbody2D>();
		var collisionNormal = (transform.position - coll.gameObject.transform.position).normalized;
		body.AddForce(collisionNormal * 7, ForceMode2D.Impulse);

		Debug.Log("hit.");
		if (coll.gameObject.tag == "l1_bullet")
			{
			isHitByBullet = true;
			Debug.Log("hit by bullet.");
			}
		}

//	private void Pulse()
//		{
//		//StartPulse = true;
////		var t = 999f;
////		var num = 0;
////
////		if (Time.time - t > 2f && num < 6)
////			{
////			gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
////			num = num + 1;
////			t = Time.time;
////			}
////		if (Time.time - t > 0.5f && Time.time -t < 2f &&num < 6)
////			{
////			gameObject.GetComponent<SpriteRenderer>().color = Color.black;
////			}
//		}

	private float _lastRange;
	private void DrawVisibilityRange()
		{
		if (_lastRange != _visibilityRange)
			{
			var lineRenderer = GetComponent<LineRenderer>();
			var offset = new Vector3(_visibilityRange, 0, 0);
			var numSegments = lineRenderer.positionCount - 1;
			var angleIncrement = 360.0f / numSegments;
			for (var i = 0; i < numSegments; i++)
				{
				var newPos = Quaternion.Euler(0, 0, angleIncrement * i) * offset;
				lineRenderer.SetPosition(i, newPos);
				}
			lineRenderer.SetPosition(numSegments, offset);
			_lastRange = _visibilityRange;
			}
		}

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// NODES
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	////////////////////
	// Conditions
	////////////////////
	private class IsInDanger : Node<Enemy_bt>
		{
		public override bool Update(Enemy_bt enemy)
			{
			return enemy._health < MaxHealth / 4;
			}
		}

//	private class IsPlayerInRange : Node<Enemy_bt>
//		{
//		public override bool Update(Enemy_bt enemy)
//			{
//			var playerPos = enemy._player.transform.position;
//			var enemyPos = enemy.transform.position;
//			return Vector3.Distance(playerPos, enemyPos) < enemy._visibilityRange;
//			}
//		}
//
//	private class IsPlayerOutRange : Node<Enemy_bt>
//		{
//		public override bool Update(Enemy_bt enemy)
//			{
//			var playerPos = enemy._player.transform.position;
//			var enemyPos = enemy.transform.position;
//			return Vector3.Distance(playerPos, enemyPos) > enemy._visibilityRange;
//			}
//		}
	
	private class IsPlayerInCircle : Node<Enemy_bt>
		{
		public override bool Update(Enemy_bt enemy)
			{
			var playerPos =enemy. _player.transform.position;
			var enemyPos = enemy.transform.position;
			return Vector3.Distance(playerPos, enemyPos) < 10f;
			}
		}
	private class IsPlayerOutCircle : Node<Enemy_bt>
		{
		public override bool Update(Enemy_bt enemy)
			{
			var playerPos = enemy._player.transform.position;
			var enemyPos = enemy.transform.position;
			return Vector3.Distance(playerPos, enemyPos) > 10f;
			}
		}

	private class IsHit : Node<Enemy_bt>
		{
		public override bool Update(Enemy_bt enemy)
			{
			var isHit = enemy.isHitByBullet;
			return isHit;
			}
		}
	private class IsTimeOut : Node<Enemy_bt>
		{
		public override bool Update(Enemy_bt enemy)
			{
			var tt = enemy.t;
			return tt > 10f;
			}
		}



	///////////////////
	/// Actions
	///////////////////

	private class Seek : Node<Enemy_bt>
		{
		public override bool Update(Enemy_bt enemy)
			{
			enemy.SetColor(Color.green);
			enemy.MoveTowardsPlayer();
			enemy.RecordTime();
			return true;
			}
		}
	private class PreAttack : Node<Enemy_bt>
		{
		public override bool Update(Enemy_bt enemy)
			{

			enemy.SetColor(Color.cyan);
			//enemy.Pulse();
			return true;
			}
		}

	
	private class Flee : Node<Enemy_bt>
		{
		public override bool Update(Enemy_bt enemy)
			{
			enemy.SetColor(Color.yellow);
			enemy.MoveAwayFromPlayer();
			return true;
			}
		}

	private class Attack : Node<Enemy_bt>
		{
		public override bool Update(Enemy_bt enemy)
			{
			enemy.SetColor(Color.red);
			enemy.MoveTowardsPlayer();
			return true;
			}
		}

	private class Idle : Node<Enemy_bt>
		{
		public override bool Update(Enemy_bt enemy)
			{
			enemy.SetColor(Color.blue);
			return true;
			}
		}


	}

