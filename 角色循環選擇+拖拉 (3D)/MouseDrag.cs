using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MouseDrag : MonoBehaviour {

	float StartX;
	float Displacement;   //位移
	Vector3 MousePos;
	Vector3 Offset;
	Vector3 ClickPos;
	float PreX;
	public bool Draggable;
	GameObject Controller;

	// Use this for initialization
	void Start () {
		
		PreX = transform.position.x;
		Controller = GameObject.Find ("Controller");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		if (Draggable == true) {
			StartX = Input.mousePosition.x;
			//ClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//ClickPos = Camera.main.WorldToScreenPoint(Input.mousePosition);
			ClickPos = Input.mousePosition;
			Offset = transform.position - ClickPos;
			//Debug.Log (Offset);
		}
	}
	void OnMouseDrag(){
		if(Draggable==true){
		Displacement = Input.mousePosition.x - StartX;
		//Debug.Log (Displacement);
			//MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			MousePos=Input.mousePosition;
			transform.position =new Vector3(MousePos.x+Offset.x,transform.position.y, transform.position.z);
			if(Displacement>60){
				Controller.SendMessage ("Moving", 2);
				//Debug.Log ("Right");
			}
			if (Displacement < -60) {
				Controller.SendMessage ("Moving", 1);
				//Debug.Log ("Left");
			}
		}

	}
	void OnMouseUp(){
		if (Draggable == true) {
			if (Mathf.Abs (Displacement) < 60) {
				transform.position = new Vector3 (PreX, transform.position.y, transform.position.z);
			}
		}
	}

	void GetPreX(Vector3 Pos){
		PreX = Pos.x;
	}

}//End
