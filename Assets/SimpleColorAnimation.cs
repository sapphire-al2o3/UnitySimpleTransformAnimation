using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleColorAnimation : MonoBehaviour
{
	[SerializeField]
	Color start = new Color(1.0f, 1.0f, 1.0f, 1.0f);

	[SerializeField]
	Color end = new Color(0.0f, 0.0f, 0.0f, 1.0f);

	[SerializeField]
	AnimationCurve curve;

	[SerializeField]
	float duration = 1.0f;

	[SerializeField]
	float offset = 0.0f;

	[SerializeField]
	Renderer _renderer;

	float _time;
	
	static MaterialPropertyBlock _mpb;

	void Awake()
	{
		if (_mpb == null)
		{
			_mpb = new MaterialPropertyBlock();
		}
		_time += offset;
	}

	void Update()
	{
		float time = (_time / duration);
		float t = curve.Evaluate(time);
		_mpb.SetColor("_Color", Color.Lerp(start, end, t));

		_renderer.SetPropertyBlock(_mpb);

		_time += Time.deltaTime;

		if (_time > duration * 2.0f)
		{
			_time -= duration * 2.0f;
		}
	}
}
