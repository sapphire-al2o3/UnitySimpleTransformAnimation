using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSimpleColorAnimationGroup : MonoBehaviour
{
	[SerializeField]
	int num = 10;

	void Start()
	{
		var animGroup = GetComponent<SimpleColorAnimationGroup>();
		Renderer[] renderers = new Renderer[num];

		for (int i = 0; i < num; i++)
		{
			var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			float x = (i / 10) * 2.0f;
			float z = (i % 10) * 2.0f;
			cube.transform.SetParent(transform);
			cube.transform.localPosition = new Vector3(x, 0.0f, z);
			renderers[i] = cube.GetComponent<Renderer>();
		}

		animGroup._renderers = renderers;
    }
}
