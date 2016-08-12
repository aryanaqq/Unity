using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scrolling123 : MonoBehaviour {

    WaitForSeconds Wait1s = new WaitForSeconds(1f);
    WaitForSeconds Wait05s = new WaitForSeconds(0.5f);
    float PreY;                            //原始local.Y
    public float Bottom;                   //循環的底
    //public GameObject G;                   //輸入欄
    //string GetText;                        //輸入欄的值
    //public GameObject Hundred;             //百位數
    //public GameObject Tens;                //十位數
    public float Speed;                    //轉動速度
    public int NO;                         //幾位數的編號
    float Num;                               //初始顯示的數字
    string[] CircleNum = new string[10];   //循環字用
    public int t = 2;                        //轉圈圈數
    int tSave;


    void Awake() {
        tSave = t;
        PreY = transform.localPosition.y; tSave = t;
    }

    public void Count() {
        t = tSave;
        transform.localPosition = new Vector3(transform.localPosition.x, PreY, transform.localPosition.z);
        switch (NO) {
            case 0:
            /*GetText = G.GetComponent<Text>().text;
            Num = int.Parse(GetText) % 10;*/
            Num = Controller.WagerSave % 10;
            for (int i = 0; i < 10; i++) {
                CircleNum[i] = ((Num + i) % 10).ToString();
            }
            GetComponent<Text>().text = CircleNum[0] + CircleNum[1] + CircleNum[2] + CircleNum[3] + CircleNum[4] + CircleNum[5] + CircleNum[6] + CircleNum[7] + CircleNum[8] + CircleNum[9] + CircleNum[0].ToString();
            StartCoroutine("Moving");
            break;
            case 1:
            /*GetText = G.GetComponent<Text>().text;
            Num = (int.Parse(GetText) % 100 - int.Parse(GetText) % 10) / 10;*/
            Num = (Controller.WagerSave % 100 - Controller.WagerSave % 10) / 10;
            for (int i = 0; i < 10; i++) {
                CircleNum[i] = ((Num + i) % 10).ToString();
            }
            GetComponent<Text>().text = CircleNum[0] + CircleNum[1] + CircleNum[2] + CircleNum[3] + CircleNum[4] + CircleNum[5] + CircleNum[6] + CircleNum[7] + CircleNum[8] + CircleNum[9] + CircleNum[0].ToString();
            StartCoroutine("Moving");
            break;
            case 2:
            /*GetText = G.GetComponent<Text>().text;
            Num = int.Parse(GetText) / 100;*/
            Num = Controller.WagerSave / 100;
            for (int i = 0; i < 10; i++) {
                CircleNum[i] = ((Num + i) % 10).ToString();
            }
            GetComponent<Text>().text = CircleNum[0] + CircleNum[1] + CircleNum[2] + CircleNum[3] + CircleNum[4] + CircleNum[5] + CircleNum[6] + CircleNum[7] + CircleNum[8] + CircleNum[9] + CircleNum[0].ToString();
            StartCoroutine("Moving");
            break;
            default:
            break;
        }
    }


    IEnumerator Moving() {
        yield return Wait05s;
        switch (NO) {
            case 0:
            yield return Wait1s;
            break;
            case 1:
            yield return Wait05s;
            break;
            case 2:           
            break;
        }
        while (t > 0 && transform.localPosition.y > Bottom) {
            transform.Translate(Vector3.up * Speed * -1);
            yield return null;
            if (transform.localPosition.y <= Bottom) {
                t -= 1;
                if (t == 0) {
                    GetComponent<Text>().text = "0";
                    gameObject.SetActive(false);
                    StopCoroutine("Moving");
                }
                else {
                    transform.localPosition = new Vector3(transform.localPosition.x, PreY, transform.localPosition.z);                   
                }
            }
        }
        yield return null;
    }

}//End
