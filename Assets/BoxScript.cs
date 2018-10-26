using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BoxScript : MonoBehaviour {

	public Animator ani;
	public GameObject Cat;

	public void OnMouseDown(){
		if (ani.GetBool("State")) {
			Close ();
		}
		else {
			Open ();
		};
	}

	public int Id = 0;
	public int CatType = 0;

	void Open(){
		ani.SetBool ("State", true);
		//gameObject.SetActive (false);
		Cat.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y+1.0f, gameObject.transform.position.z);
		Cat.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		//if (Cats.cats == null) {
		//	Cats.cats = new Cats ();
		//}
		//Cats.cats.SelectBox (this);
	}

	void Close(){
		ani.SetBool ("State", false);
		//gameObject.SetActive (true);
		Cat.transform.position = gameObject.transform.position;
		Cat.transform.localScale = new Vector3 (0.5f, 0.35f, 0.5f);
	}

	public void Terminate()
	{
		Destroy (Cat);
		Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		//GameObject Cat = new GameObject ("Cat");
		string CName;
		if (CatType == 1) {
			CName = "Cat1";
		} else {CName = "Cat2";
		}
		Cat = new GameObject ("Cat");
		Instantiate(Cat);
		Cat.AddComponent<SpriteRenderer>().sprite = "кот3";
		Cat.SetActive (true);
		Close ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
