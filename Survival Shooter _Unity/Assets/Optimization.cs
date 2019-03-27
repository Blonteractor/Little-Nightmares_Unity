using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimization : MonoBehaviour
{

	#region Refrences

	private Collider collider;
	private SkinnedMeshRenderer renderer;
	private GameObject otherGO;

	#endregion

	#region Unity callbacks
	private void Awake()
	{
		collider = new Collider();
		collider = GetComponent<BoxCollider>();
	}

	private void OnTriggerEnter(Collider other)
	{
		renderer = other.GetComponentInChildren<SkinnedMeshRenderer>();
		if (renderer == null)
			return;
		renderer.enabled = true;
		if (renderer == null)
			return;
				
	}

	private void OnTriggerExit(Collider other)
	{
		renderer = other.GetComponentInChildren<SkinnedMeshRenderer>();
		if (renderer == null)
			return;
		renderer.enabled = false;
		if (renderer == null)
			return;
	}
	#endregion

	
}
