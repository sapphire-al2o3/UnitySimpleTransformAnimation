using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSelectAnimation : MonoBehaviour
{
	SimpleColorAnimation _selected;
	Camera _camera;

	private void Awake()
	{
		_camera = Camera.main;
	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			if (_selected != null)
			{
				_selected.enabled = false;
				_selected.Evaluate(0);
			}

			var ray =_camera.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
			if (Physics.Raycast(ray, out var hitInfo))
			{
				var cube = hitInfo.transform.GetComponent<SimpleColorAnimation>();
				cube.enabled = true;
				_selected = cube;
			}
		}
    }
}
