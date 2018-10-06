using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameOverScript : MonoBehaviour {
	public Button btn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}
	public void reload(){
	
		PlayerScriptScene3.score = 10;
		Application.LoadLevel ("Scene");
	}
}
