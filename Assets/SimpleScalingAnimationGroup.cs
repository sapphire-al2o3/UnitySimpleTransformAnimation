using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScalingAnimationGroup : MonoBehaviour
{
	[SerializeField]
	Vector3 start = new Vector3(1.0f, 1.0f, 1.0f);

	[SerializeField]
	Vector3 end = new Vector3(1.0f, 1.0f, 1.0f);

	[SerializeField]
	AnimationCurve curve;

	[SerializeField]
	float duration = 1.0f;

	[SerializeField]
	public float[] offsets;

	[SerializeField]
	public Transform[] transforms;

	[SerializeField]
	string colorPropertyName;

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
	}

	void Update()
	{
		for (int i = 0; i < transforms.Length; i++)
		{
			var trans = transforms[i];
			float time = _time + (offsets != null ? offsets[i] : 0.0f);
			if (time > duration * 2.0f)
			{
				time -= duration * 2.0f;
			}
			float t = curve.Evaluate(time / duration);
			trans.localScale = Vector3.Lerp(start, end, t);
		}

		_time += Time.deltaTime;

		if (_time > duration * 2.0f)
		{
			_time -= duration * 2.0f;
		}
	}
}