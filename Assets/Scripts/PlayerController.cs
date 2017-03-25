using UnityEngine;
using UniRx;
using System;
using System.Linq;

public class PlayerController : MonoBehaviour {
	void Start()
	{
		//ShowDebugLog();
		DestroyFellenPlayer();
	}

	/// <summary>
	/// PlayerのPositionを一定時間おきに監視して、指定以下になったらDestroyする。
	/// </summary>
	private void DestroyFellenPlayer()
	{
		Observable
			.Interval(TimeSpan.FromSeconds(0.5f))
			.Where(_ => transform.position.y < -8.0f)
			.Subscribe(_ =>
			{
				Debug.Log("Player Deleted!!");
				Destroy(gameObject);
			}).AddTo(gameObject);
	}

	/// <summary>
	/// デバッグ用のログ出力メソッド。
	/// </summary>
	private void ShowDebugLog()
	{
		Observable
			.Interval(TimeSpan.FromSeconds(0.2f))
			.Subscribe(_ =>
			{
				Debug.Log("position.y = " + transform.position.y);
			}).AddTo(gameObject);

		Observable
			.Interval(TimeSpan.FromSeconds(0.5f))
			.Subscribe(_ =>
			{
				Debug.Log("Update");
			}).AddTo(gameObject);
	}
}
