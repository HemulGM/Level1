using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour {

	public void SetTo(GameObject box){
		//gameObject.SetActive (true);
		transform.position = new Vector3 (box.transform.position.x, box.transform.position.y+1.5f, box.transform.position.z);
	}

	public void SetPlus(GameObject box, GameObject box2){
		//gameObject.SetActive (true);
		transform.position = new Vector3 (box.transform.position.x-(box.transform.position.x-box2.transform.position.x) / 2, box.transform.position.y+(box.transform.position.y-box2.transform.position.y) / 2, box.transform.position.z);
	}

	public void Hide(){
		//gameObject.SetActive (false);
		transform.position = new Vector3 (-100f, -100f, 0);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
