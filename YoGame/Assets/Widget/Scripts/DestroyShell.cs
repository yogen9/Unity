﻿using UnityEngine;
using System.Collections;

public class DestroyShell : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject,6.5f);
	}
}
