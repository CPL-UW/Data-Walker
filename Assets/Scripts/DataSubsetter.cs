using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSubsetter : MonoBehaviour {

	// Use this for initialization
  public List<int> userPoints;
  public BallPlacer mainCam;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  void OnMouseDown () {
    foreach (var up in userPoints){
      Debug.Log(up);

    }
    mainCam.pointViewer(userPoints);
    
  }

}
