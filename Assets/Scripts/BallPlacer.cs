using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlacer : MonoBehaviour {
	public Transform dot;
    public TextAsset textFile;
    private float[] xs;
	private float[] ys;
	private float[] zs;
    private float[] uids;
    List<Transform> plottedPoints;

	// Use this for initialization
	void Start () {
        //xs = new float[4];
        //xs = new float[] {3.4f,5.6f,7.6f,5.6f};
        //ys = new float[] {3.4f,5.6f,7.6f,6.6f};
        //zs = new float[] {3.4f,5.6f,7.6f,5.6f};
        xs = new float[500];
        ys = new float[500];
        zs = new float[500];
        plottedPoints = new List<Transform> ();
        ReadFile();
		PlotPoints ();
	}

    void ReadFile() {
        string[] lines = textFile.text.Split("\n"[0]);
        Debug.Log(lines[0]);
        for (int i = 1; i < lines.length; i++) {
            string[] numbers = lines[i].Split(","[0]);
            uids = numbers[0];
            //xs
            xs[i - 1] = float.TryParse(numbers[1]);
            ys[i - 1] = float.TryParse(numbers[2]);
            zs[i - 1] = float.TryParse(numbers[3]);
        }
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
