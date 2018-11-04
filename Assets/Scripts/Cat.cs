using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {

	private int catType = 1;

	Animator ani;

	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator>();
		CatType = catType;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public int CatType
	{
		get { return catType; }
		set { catType = value;
			if (ani != null) {
				ani.SetInteger ("CatType", catType);
			}
		} 
	}
}
