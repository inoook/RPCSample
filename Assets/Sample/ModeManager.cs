using UnityEngine;
using System.Collections;

public class ModeManager : MonoBehaviour {

	public string readme = "";

	public ViewA viewA;
	public ViewB viewB;

	public bool debug = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetModeA()
	{
		viewA.gameObject.SetActive(true);
		viewB.gameObject.SetActive(false);

		viewA.FullscreenMode(true);
	}
	void SetModeB()
	{
		viewA.gameObject.SetActive(false);
		viewB.gameObject.SetActive(true);

		viewB.FullscreenMode(true);
	}

	void OnGUI()
	{
		if(!debug){ return; }

		GUILayout.BeginArea(new Rect(300,300,200,100));
		GUILayout.Label(readme);
		if(GUILayout.Button("SetModeA")){
			SetModeA();
		}
		if(GUILayout.Button("SetModeB")){
			SetModeB();
		}
		GUILayout.EndArea();
	}
}
