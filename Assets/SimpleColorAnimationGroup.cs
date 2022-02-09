using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleColorAnimationGroup : MonoBehaviour
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
	public float[] offsets;

	[SerializeField]
	public Renderer[] renderers;

	[SerializeField]
	public string colorPropertyName = "_Color";

	float _time;

	static MaterialPropertyBlock _mpb;
	static int _colorID;

	void Awake()
	{
		if (_mpb == null)
		{
			_mpb = new MaterialPropertyBlock();
		}
		_colorID = Shader.PropertyToID(colorPropertyName);
	}

	void Update()
	{
		for (int i = 0; i < renderers.Length; i++)
		{
			var renderer = renderers[i];
			float time = _time + (offsets != null ? offsets[i] : 0.0f);
			if (time > duration * 2.0f)
			{
				time -= duration * 2.0f;
			}
			float t = curve.Evaluate(time / duration);
			_mpb.SetColor(_colorID, Color.Lerp(start, end, t));

			renderer.SetPropertyBlock(_mpb);
		}

		_time += Time.deltaTime;

		if (_time > duration * 2.0f)
		{
			_time -= duration * 2.0f;
		}
	}
}
