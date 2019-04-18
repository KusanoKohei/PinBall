using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ=-6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;
    //リスタートを表示するテキスト
    private GameObject restartText;

	// Use this for initialization
	void Start () {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        //シーン中のRestartオブジェクトを取得
        this.restartText = GameObject.Find("Restart");
	}
	
	// Update is called once per frame
	void Update () {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
            //リセットを表示
            this.restartText.GetComponent<Text>().text = "Restart \n Enter or Space KEY";
           

            //ゲームオーバー後にsubmitを押すとリスタート
            if (Input.GetButtonDown("Submit"))
            {
                FindObjectOfType<Score>().Save();
                SceneManager.LoadScene("GameScene");
            }
            
        }
	}

    //終了処理
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
