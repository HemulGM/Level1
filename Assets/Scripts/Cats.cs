using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cats {

	BoxScript Box1 = null;
	BoxScript Box2 = null;
	public static Cats cats;

	public void SelectBox(BoxScript box)
	{
		if (Box1 == null) { 
			Box1 = box; 
			return; 
		};
		if (box == Box1) {
			return;
		};
		if (Box2 == null) { 
			Box2 = box; 
		};
		if (Box1.CatType == Box2.CatType) {
			Box1.Terminate ();
			Box2.Terminate ();
			Box1 = null;
			Box2 = null;
		} else {
			Box1.Close ();
			Box2.Close ();
			Box1 = null;
			Box2 = null;
		}
	}
}
