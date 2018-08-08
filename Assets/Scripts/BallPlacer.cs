using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlacer : MonoBehaviour {
	public GameObject dot;
	private float[] xs;
	private float[] ys;
	private float[] zs;

	// Use this for initialization
	void Start () {
		//xs = new float[4];
		xs = new float[] {34,56,76,56};
		ys = new float[] {34,56,76,56};
		zs = new float[] {34,56,76,56};

		PlotPoints ();
	}

	void PlotPoints () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
