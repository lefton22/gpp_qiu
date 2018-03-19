using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task  {

	public enum TaskStatus : byte
		{
		Detached, // Task has not been attached to a TaskManager
		Pending, // Task has not been initialized
		Working, // Task has been initialized
		Success, // Task completed successfully
		Fail, // Task completed unsuccessfully
		Aborted // Task was aborted
		}


	public TaskStatus Status { get; private set; }


		protected virtual void Init() {}

		internal virtual void Update() {}

		protected virtual void CleanUp() {}


		protected virtual void OnAbort() {}

		protected virtual void OnSuccess() {}

		protected virtual void OnFail() {}
	
	public void Abort()
		{
		SetStatus(TaskStatus.Aborted);
		}

	internal void SetStatus(TaskStatus newStatus)
		{
		if (Status == newStatus) return;

		Status = newStatus;

		switch (newStatus)
			{

			case TaskStatus.Working:
				Init();
				break;

			case TaskStatus.Success:
				OnSuccess();
				CleanUp();
				break;

			case TaskStatus.Aborted:
				OnAbort();
				CleanUp();
				break;

			case TaskStatus.Fail:
				OnFail();
				CleanUp();
				break;

			case TaskStatus.Detached:
			case TaskStatus.Pending:
				break;

			}
		}

			public bool IsDetached { get { return Status == TaskStatus.Detached; } }
			public bool IsAttached { get { return Status != TaskStatus.Detached; } }
			public bool IsPending { get { return Status == TaskStatus.Pending; } }
			public bool IsWorking { get { return Status == TaskStatus.Working; } }
			public bool IsSuccessful { get { return Status == TaskStatus.Success; } }
			public bool IsFailed { get { return Status == TaskStatus.Fail; } }
			public bool IsAborted { get { return Status == TaskStatus.Aborted; } }
			public bool IsFinished { get { return (Status == TaskStatus.Fail || Status == TaskStatus.Success || Status == TaskStatus.Aborted); } }

	public Task NextTask { get; private set; }

	//Monad
	public Task Then(Task task)
		{
		Debug.Assert(!task.IsAttached);
		NextTask = task;
		return task;
		}
}
