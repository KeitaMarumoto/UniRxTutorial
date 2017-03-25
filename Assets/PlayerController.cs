using UnityEngine;
using UniRx;
using System;
using System.Linq;

public class PlayerController : MonoBehaviour {
	void Start()
	{
		Observable
			.Interval(TimeSpan.FromSeconds(0.3f))
			.Subscribe(_ => Debug.Log("position.y = " + transform.position.y))
			.AddTo(this);

		Observable
			.Interval(TimeSpan.FromSeconds(1.5f))
			.Subscribe(_ => Debug.Log("Update"))
			.AddTo(this);

		//PlayerのPositionを一定時間おきに監視して、指定以下になったらDestroyする。
		Observable
			.Interval(TimeSpan.FromSeconds(1.5f))
			.Where(_ => transform.position.y < -20.0f)
			.Subscribe(_ =>
			{
				Debug.Log("Player Deleted!!");
				Destroy(gameObject);
			}).AddTo(this);
	}
}
