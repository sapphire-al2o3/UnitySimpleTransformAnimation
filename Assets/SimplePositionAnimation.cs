using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePositionAnimation : MonoBehaviour
{
	[SerializeField]
	Vector3 start = new Vector3(0.0f, 0.0f, 0.0f);

	[SerializeField]
	Vector3 end = new Vector3(0.0f, 0.0f, 0.0f);

	[SerializeField]
	AnimationCurve curve;

	[SerializeField]
	float duration = 1.0f;

	[SerializeField]
	float offset = 0.0f;

	float _time;

	void Awake()
	{
		_time += offset;
	}

	void Update()
	{
		float time = (_time / duration);
		float t = curve.Evaluate(time);
		transform.localPosition = Vector3.Lerp(start, end, t);

		_time += Time.deltaTime;

		if (_time > duration * 2.0f)
		{
			_time -= duration * 2.0f;
		}
	}
}
