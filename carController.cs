using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {

	public float carSpeed;
	Vector3 position;
	public UiManager ui;
	public audioManagerScript am;

	public trackMove trackMov;
	void Start () {
		InvokeRepeating ("StarSound",9f,12000f);
		position = transform.position;

	}

	void StarSound(){
		am.carSound.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
		position.x  = position.x +Input.GetAxis ("Horizontal")*carSpeed *Time.deltaTime;
		Debug.Log (transform.position);
		Debug.Log ("Time.deltaTime "+Time.deltaTime);

		position.x=Mathf.Clamp (position.x, -2.1f, 2.1f);
			transform.position=position;
		

	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Enemy Car") {
			Destroy (gameObject);
			ui.gameOver ();
			am.carSound.Stop ();
			trackMov.speed = 0;
		}
	}
}
