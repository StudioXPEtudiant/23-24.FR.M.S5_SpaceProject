using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMotion : MonoBehaviour
{
    public Transform targetLimb;
    ConfigurableJoint cj;

	private void Start()
	{
		cj = GetComponent<ConfigurableJoint>();
	}

	private void Update()
	{
		ConfigurableJointExtensions.SetTargetRotationLocal(cj, targetLimb.localRotation, transform.localRotation);
	}
}
