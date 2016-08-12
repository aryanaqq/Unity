using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class ScrollingText : MonoBehaviour {

	public float  Border;   //右側邊界
	public float speed=300;
	//List<string>MSGS=new List<string>();     //接受訊息
	Dictionary<int,string>Messages=new Dictionary<int,string>();  //int=>No編號 string內容
	int SaveNo;                             //儲存的編號
	int No;                                 //編號
	//public GameObject InputField;
	public GameObject Panel;
	//bool running;
	bool startrun;
	string s;           //顯示的內容
	Vector3 PrePos;     //初始位置

    //public static string IpServer = "127.0.0.1";
    string MSG;         //存起來的總內容
    string NickName;
    string WinMoney;
    bool B_GetMSG=false;
   
    void Start () {
		No = 0;
		SaveNo = 0;
		startrun = false;
		//running = false;
		PrePos = gameObject.GetComponent<RectTransform> ().localPosition;
        //Border = Panel.GetComponent<RectTransform> ().sizeDelta.x;
        //Debug.Log (Border);
    /*    try
        {
            Net.Instance.SetUrl(IpServer + ":" + PortSet.ServerPort);
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
        Net.Instance.ReplyAction(ReplyActionType.LotteryWinner, LotteryWinnerCallback);
        Login();
        */
    }

	// Update is called once per frame
	void Update () {
        //Debug.Log ("NO"+"  "+No);
        //Debug.Log ("SaveNO"+"  "+SaveNo);
        //Debug.Log(Messages.Count);
        if (B_GetMSG == true)
        {
            if (Messages.Count <= 0)
            {
                Messages.Clear();
                Messages = new Dictionary<int, string>();
                //Debug.Log ("Clear");
            }
            //string m = InputField.GetComponent<InputField> ().text;
            MSG = ("恭喜玩家: " + NickName + " 获得奖金 " + WinMoney).ToString();
            Messages.Add(SaveNo, MSG);
            SaveNo += 1;
            //InputField.GetComponent<InputField>().text = "";
            if (startrun == false)
            {
                //running = true;
                s = Messages[No];
                gameObject.GetComponent<Text>().text = s;
                StartCoroutine("Marquee");
                
            }
            
            B_GetMSG = false;
        }
	}
 


	IEnumerator Marquee(){

		while (Messages.Count!=0) {
			startrun = true;
			gameObject.transform.Translate (Vector3.left * Time.deltaTime * speed, Space.World);

            if (gameObject.transform.localPosition.x < Border) {
             	//running = false;
				startrun = false;
				gameObject.transform.localPosition = PrePos;
				No += 1;

				if (Messages.ContainsKey(No)) {
					s = Messages [No];
				}
					Messages.Remove (No-1);
					gameObject.GetComponent<Text> ().text = s;
	
			}
            B_GetMSG = false;
            yield return null;
		}
	}

	/*public void GetMSG(string x){ 
		if (Messages.Count <= 0) {
			Messages.Clear ();
			Messages = new Dictionary<int,string> ();
			//Debug.Log ("Clear");
		}	
		//string m = InputField.GetComponent<InputField> ().text;
      
		Messages.Add (SaveNo, MSG);
		SaveNo += 1;
		InputField.GetComponent<InputField> ().text = "";
			if (startrun == false) {
				//running = true;
				s = Messages [No];
				gameObject.GetComponent<Text> ().text = s;
				StartCoroutine ("Marquee");
			}
		
	}*/
    void LotteryWinnerCallback(byte[] data)
    {
        var result = ProtobufHelper.Deserialize<LotteryWinnerResult>(data);
        NickName = result.NickName;
        WinMoney = result.WinMoney.ToString("N0");
        B_GetMSG = true;
    }
    /*public void Login()
    {
        IPHostEntry ip = Dns.GetHostEntry(Dns.GetHostName());
        var ipaddress = ip.AddressList.FirstOrDefault(i => i.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
        //var username = UserNameNow;
        // var pwd = Password.text;


        var ps = new Dictionary<string, string>();
        ps["UserName"] = "test1";
        ps["Password"] = "0";
        ps["IPAddress"] = ipaddress.ToString();

        try
        {
            //登入
            Net.Instance.SocketSend(SendActionType.Login, loginCallback, ps);
        }
        catch (Exception e)
        {
            // ErrorShow.text = e.ToString();
            Debug.Log("Logging Failed");
        }
    }
    private void loginCallback(byte[] data)
    {
        var result = ProtobufHelper.Deserialize<UserInfoResult>(data);
        if (result.ErrorCode != 0)
        {
            Debug.Log("登陆错误:" + result.ErrorInfo);
            return;
        }
        // CurrentLoginResult = result;
        Debug.Log("登陆成功，开始加载游戏模式列表！");
        //NextScene = true; //bool 執行
    }*/
}//End
