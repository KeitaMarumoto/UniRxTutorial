using UnityEngine;
using UniRx;
using System;
using System.Linq;
using System.Collections.Generic;

public class SphereManager : MonoBehaviour {
	[SerializeField]
	private List<GameObject> _spheres;

	void Start ()
	{
		//ShowCountTime();
		ShowSpherePosition();
		DestroySphere();
	}

	/// <summary>
	/// 何秒経過したかログに出力させる。
	/// </summary>
	private void ShowCountTime()
	{
		int _time = 0;
		Observable
			.Interval(TimeSpan.FromSeconds(1.0f))
			.Subscribe(_ =>
			{
				_time++;
				Debug.Log(_time);
			}).AddTo(this);
	}

	/// <summary>
	/// 指定時間経過後に"AnotherSphere"のタグを持つ_spheresの中の要素をDestroyする。
	/// </summary>
	private void DestroySphere()
	{
		Observable
			.Timer(TimeSpan.FromSeconds(5.1f))
			.Subscribe(_ =>
			{
				_spheres
					.Where(s => s.tag == "AnotherSphere")
					.ToObservable()
					.Subscribe(s => Destroy(s));

				Destroy(this);
			}).AddTo(this);
	}

	/// <summary>
	/// 指定時間経過後に、"Sphere"のタグを持つSphereのPositionを
	/// Vector3からStringに直して出力させる。
	/// </summary>
	private void ShowSpherePosition()
	{
		Observable
			.Timer(TimeSpan.FromSeconds(1.0f))
			.Subscribe(_ =>
			{
				_spheres
				.Where(s => s.tag == "Sphere")
				.Select(s => s.transform.position.ToString())
				.ToObservable()
				.Subscribe(s => Debug.Log(s));
			}).AddTo(this);
	}
}
