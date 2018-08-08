using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlacer : MonoBehaviour {
	public Transform dot;
	private float[] xs;
	private float[] ys;
	private float[] zs;
	List<Transform> plottedPoints;

	// Use this for initialization
	void Start () {
		//xs = new float[4];
		xs = new float[] {3.4f,5.6f,7.6f,5.6f};
		ys = new float[] {3.4f,5.6f,7.6f,6.6f};
		zs = new float[] {3.4f,5.6f,7.6f,5.6f};
		plottedPoints = new List<Transform> ();
		PlotPoints ();
	}

	void PlotPoints () {
		for (int i = 0; i < xs.Length; i++) {
			//plottedPoints.Add (Instantiate (dot, new Vector3(xs[i], ys[i], zs[i])) as Transform);
			//Instantiate (dot, new Vector3(xs[i], ys[i], zs[i]));
			Transform newPoint = Instantiate (dot, new Vector3(xs[i], ys[i], zs[i]), Quaternion.identity) as Transform;
			plottedPoints.Add (newPoint);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
