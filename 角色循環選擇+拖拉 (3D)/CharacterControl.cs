using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CharacterControl : MonoBehaviour {


	public int All=10;
	public GameObject[] Chars=new GameObject[10];     //圖片PLANE
	public GameObject[] Positions=new GameObject[10];  //位置CUBE
	MouseDrag A;    //拖拉語法
	int TheOne;   //玩家目前所選
	int L=1;    //左翻次數
	int R=1;    //右翻次數
	int m;     //控制排序
	public Material Pre;
	public Material Chosed;     //選中物件所改變之材質

 
	// Use this for initialization
	void Start () {
		TheOne = 2;
		A = Chars [TheOne].GetComponent<MouseDrag> ();
		A.Draggable = true;
		for (int i = 0; i < Positions.Length; i++) {
			Chars [i].transform.position = Positions [i].transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void Moving(int x){  //向左拉1向右拉2
		if(x==1){
			for (int i = 0; i < Positions.Length; i++) {
				m =i-L;
				if (m < 0) {
					m += All;
				}
				Chars [i].transform.DOMove (Positions [m%All].transform.position,0.1f);
				Chars [i].SendMessage ("GetPreX", Positions [m%All].transform.position);
				//Debug.Log ("L"+i);
				//Debug.Log ("L"+m%10);

			}
			L += 1;
			R-=1 ;
			if (L > All-1) {
				L = 0;
			}
			if (L < 0) {
				L = 0;
			}
			if (R > All-1) {
				R = 0;
			}
			if (R < 0) {
				R = All-1;
			}
		
			A = Chars [TheOne].GetComponent<MouseDrag> ();
			A.Draggable = false;
			Chars [TheOne].GetComponent<MeshRenderer> ().material =Pre;
			TheOne+=1;
			if (TheOne > All-1) {
				TheOne = 0;
			}
			if (TheOne < 0) {
				TheOne = All-1;
			}
			A = Chars [TheOne].GetComponent<MouseDrag> ();
			A.Draggable = true;
			Chars [TheOne].GetComponent<MeshRenderer> ().material = Chosed;
		}
		if (x == 2) {
			for (int i = 0; i < Positions.Length; i++) {
				
				 m = i+R;
				if (m > All) {
					m = m % All;
				}
				//Debug.Log ("R"+i);
				//Debug.Log ("R"+m%10);
			
				Chars [i].transform.DOMove (Positions [m%All].transform.position,0.1f);
				Chars [i].SendMessage ("GetPreX",Positions[m%All].transform.position);
			}
			R += 1;
			L-=1;
			if (R > All-1) {
				R =0;
			}
			if (R < 0) {
				R = 0;
			}
			if (L > All-1) {
				L =0;
			}
			if (L < 0) {
				L =All-1;
			}


			A = Chars [TheOne].GetComponent<MouseDrag> ();
			A.Draggable = false;
			Chars [TheOne].GetComponent<MeshRenderer> ().material = Pre;
			TheOne-=1;
			if (TheOne > All-1) {
				TheOne = 0;
			}
			if (TheOne < 0) {
				TheOne = All-1;
			}

			//Debug.Log (TheOne);
			A = Chars [TheOne].GetComponent<MouseDrag> ();
			A.Draggable = true;
			Chars [TheOne].GetComponent<MeshRenderer> ().material = Chosed;
		}
		//Debug.Log ("L"+L);
		//Debug.Log ("R"+R);
		//Debug.Log(m);
	}


}//End
