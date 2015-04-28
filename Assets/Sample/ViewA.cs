using UnityEngine;
using System.Collections;

public class ViewA : MonoBehaviour {

	public string readme = "";
	public ViewConnector viewConnector;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int currentId = -1;

	public void SelectContent(int id)
	{
		currentId = id;

		viewConnector.SelectContent(id);
	}

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(300,0,200,300));
		GUILayout.Label(readme);
		GUILayout.Label("currentId: "+currentId);
		if(GUILayout.Button("0")){
			SelectContent(0);
		}
		if(GUILayout.Button("1")){
			SelectContent(1);
		}
		if(GUILayout.Button("2")){
			SelectContent(2);
		}
		GUILayout.EndArea();
	}

	//
	public Camera viewCam;
	public void FullscreenMode(bool enable)
	{
		Rect rect;
		if(enable){
			rect = new Rect(0, 0, 1, 1);
		}else{
			rect = new Rect(0, 0, 0.5f, 0.5f);
		}
		viewCam.rect = rect;
	}
}
