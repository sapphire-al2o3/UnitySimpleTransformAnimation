using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSimpleRotationAnimationGroup : MonoBehaviour
{
	[SerializeField]
	int num = 10;

	void Start()
	{
		var animGroup = GetComponent<SimpleRotationAnimationGroup>();
		Transform[] transforms = new Transform[num];
		float[] offsets = new float[num];

		for (int i = 0; i < num; i++)
		{
			var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			float x = (i / 10) * 2.0f;
			float z = (i % 10) * 2.0f;
			cube.transform.SetParent(transform);
			cube.transform.localPosition = new Vector3(x, 0.0f, z);
			transforms[i] = cube.transform;
			offsets[i] = (float)i / num;
		}

		animGroup.transforms = transforms;
		animGroup.offsets = offsets;

	}
}
