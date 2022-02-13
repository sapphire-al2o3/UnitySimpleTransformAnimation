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
	string colorPropertyName;

	Renderer _renderer;
	float _time;
	int _colorID;

	static MaterialPropertyBlock _mpb;

	void Awake()
	{
		if (_mpb == null)
		{
			_mpb = new MaterialPropertyBlock();
		}
		if (string.IsNullOrEmpty(colorPropertyName))
		{
			colorPropertyName = "_Color";
		}
		_colorID = Shader.PropertyToID(colorPropertyName);
		_renderer = GetComponent<Renderer>();
		_time += offset;
	}

	public void Evaluate(float t)
	{
		float v = curve.Evaluate(t);
		_mpb.SetColor(_colorID, Color.Lerp(start, end, v));

		_renderer.SetPropertyBlock(_mpb);
	}

	void Update()
	{
		float time = _time / duration;
		Evaluate(time);

		_time += Time.deltaTime;

		if (_time > duration * 2.0f)
		{
			_time -= duration * 2.0f;
		}
	}
}
