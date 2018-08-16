using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlacer : MonoBehaviour {
	public Transform dot;
  public TextAsset textFile;
  private float[] xs;
	private float[] ys;
	private float[] zs;
  private string[] uids;
  List<Transform> plottedPoints;
  Dictionary<string, Color> uidColors;
  Dictionary<string, List<int>> uidPoints;
  bool subsetView;

	// Use this for initialization
	void Start () {
    //xs = new float[4];
    //xs = new float[] {3.4f,5.6f,7.6f,5.6f};
    //ys = new float[] {3.4f,5.6f,7.6f,6.6f};
    //zs = new float[] {3.4f,5.6f,7.6f,5.6f};
    xs = new float[500];
    ys = new float[500];
    zs = new float[500];
    uids = new string[500];
    plottedPoints = new List<Transform> ();
    uidColors = new Dictionary<string, Color>();
    uidPoints = new Dictionary<string, List<int>>();
    subsetView = false;

    ReadFile();
  	PlotPoints ();
	}

    void ReadFile() {
      string[] lines = textFile.text.Split("\n"[0]);
      
      for (int i = 1; i < lines.Length; i++) {
          // Debug.Log(lines[i]);
          string[] numbers = lines[i].Split(","[0]);
          if (numbers.Length > 3) {
            // Debug.Log(numbers[0] + " " + numbers[1] + " " + numbers[2]);

            uids[i - 1] = numbers[0];
            if (!uidColors.ContainsKey(numbers[0])){
              uidColors[numbers[0]] = Random.ColorHSV();
              
            }
            if (!uidPoints.ContainsKey(numbers[0])) {
              uidPoints[numbers[0]] = new List<int>();
            }
            uidPoints[numbers[0]].Add(i - 1); 

            //xs
            // bool res = float.TryParse(numbers[1], out xs[i - 1]);
            float.TryParse(numbers[1], out xs[i - 1]);
            float.TryParse(numbers[2], out ys[i - 1]);
            float.TryParse(numbers[3], out zs[i - 1]);
          }
      }
  }

  public void pointViewer(List<int> pointList) {
    if (subsetView == true) {
      subsetView = false;
      foreach (var p in plottedPoints) {
        p.GetComponent<Renderer>().enabled = true;
      }
    }
    else {
      subsetView = true;
      foreach (var p in plottedPoints) {
        p.GetComponent<Renderer>().enabled = false;
      }
      foreach (int i in pointList) {
        plottedPoints[i].GetComponent<Renderer>().enabled = true;
      }
    }
    // Debug.Log(pointList[0]);
  }

	void PlotPoints () {
		for (int i = 0; i < xs.Length; i++) {
			//plottedPoints.Add (Instantiate (dot, new Vector3(xs[i], ys[i], zs[i])) as Transform);
			//Instantiate (dot, new Vector3(xs[i], ys[i], zs[i]));
			Transform newPoint = Instantiate (dot, new Vector3(xs[i], ys[i], zs[i]), Quaternion.identity) as Transform;
      // Debug.Log(uids[i]);
      newPoint.GetComponent<Renderer>().material.color = uidColors[uids[i]];
      newPoint.GetComponent<DataSubsetter>().userPoints = uidPoints[uids[i]];
      newPoint.GetComponent<DataSubsetter>().mainCam = this;
      // newPoint.userPoints = uidPoints[uids[i]];
			plottedPoints.Add (newPoint);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
