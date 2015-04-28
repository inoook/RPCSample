using UnityEngine;
using System.Collections;

public class ViewB : MonoBehaviour {
	
	public GameObject cubeGObj;
	public TextMesh labelTextMesh;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int receive_currentId = -1;

	public void SelectContent(int id)
	{
		Debug.Log("SelectContent: "+id);

		receive_currentId = id;

		cubeGObj.transform.localPosition = new Vector3(id, 0, 0);
		labelTextMesh.text = receive_currentId.ToString();
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
