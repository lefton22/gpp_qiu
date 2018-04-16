using System.Collections;
using UnityEngine;

public class boss : MonoBehaviour
	{
	private readonly TaskManager _tm = new TaskManager();

	private void Start ()
		{
		DoMyThing();
		}

	private void Update ()
		{
		_tm.Update();
		}

	private void DoMyThing()
		{

		var startPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));
		//var startPos = new Vector3(-3.8f, 8.1f, 0.175f);
		var endPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 10));
		var midPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));

		var startScale = Vector3.one;
		var endScale = startScale * 2;

		_tm.Do(new SetPos(gameObject, startPos))


			.Then(new SetScale(gameObject, new Vector3(0.1f, 0.1f, 0.1f),new Vector3(1f, 01f, 1f), 1.5f))

		
			.Then(new Scale(gameObject, startScale, endScale, 0.25f));

		print("DoMyThings");
		}

	}

public class Rotate : TimedGOTask
	{
	private readonly Vector3 _startRotation, _endRotation;

	public Rotate(GameObject gameObject, Vector3 startRotation, Vector3 endRotation, float duration) : base(gameObject, duration)
		{
		_startRotation = startRotation;
		_endRotation = endRotation;
		}

	protected override void OnTick(float t)
		{
		gameObject.transform.rotation = Quaternion.Euler(Vector3.Lerp(_startRotation, _endRotation, t));
		}
	}



////   ////// //////












