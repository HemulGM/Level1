using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cats : MonoBehaviour {

	BoxScript Box1 = null;
	BoxScript Box2 = null;
	public static Cats cats;

	// Use this for initialization
	void Start () {
		cats = new Cats();
	}

	public void SelectBox(BoxScript box)
	{
		if (Box1 == null) { Box1 = box; return; };
		if (Box2 == null) { Box2 = box; return; };
		if (Box1.CatType == Box2.CatType) {
			Box1.Terminate ();
			Box2.Terminate ();
			Box1 = null;
			Box2 = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
