using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePositionAnimationGroup : MonoBehaviour
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
	public float[] offsets;

	[SerializeField]
	public Transform[] transforms;

	float _time;

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
			transform.localPosition = Vector3.Lerp(start, end, t);
		}

		_time += Time.deltaTime;

		if (_time > duration * 2.0f)
		{
			_time -= duration * 2.0f;
		}
	}
}
