using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        //タッチコントロール関数取得
        touch_control();

            //左矢印キーを押した時左フリッパーを動かす
            if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            //右矢印キーを押した時右フリッパーを動かす
            if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            //タッチを離した瞬間にフリッパーを戻す || 矢印キー離された時フリッパーを元に戻す
            if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
    }


    //タッチ操作関数
    void touch_control()
    {

        //画面サイズを取得
        int width = Screen.width;
        int height = Screen.height;

        //タッチされた座標を検出
        var x = Input.mousePosition.x;
        var y = Input.mousePosition.y;


        //タッチされているかチェック
        if (Input.touchCount > 0)
        {
            Touch[] mytouches = Input.touches;

            for(int i=0; i < mytouches.Length; i++) { 
                //もし画面左側がタッチされたなら
                if ((mytouches[i].phase == TouchPhase.Began)&&(x<=(width/2)) && tag == "LeftFripperTag")
                {
                    //Debug.Log("左側");
                    SetAngle(this.flickAngle);
                }

                //もし画面左側にタッチした手が離れたなら
                if ((mytouches[i].phase == TouchPhase.Ended) && (x <= (width / 2)) && tag == "LeftFripperTag")
                {
                    //Debug.Log("左側、無効");
                    SetAngle(this.defaultAngle);

                }

                //もし画面右側がタッチされたなら
                if ((mytouches[i].phase == TouchPhase.Began) && ((width / 2) < x) && tag == "RightFripperTag")
                {
                    //Debug.Log("右側");
                    SetAngle(this.flickAngle);
                }

                //もし画面右側にタッチした手が離れたなら
                if ((mytouches[i].phase == TouchPhase.Ended) && ((width / 2) < x) && tag == "RightFripperTag")
                {
                    //Debug.Log("右側、無効");
                    SetAngle(this.defaultAngle);
                }

            }
            /*


            
                //画面左側をタッチした時に左フリッパーを動かす
                if ((hidari=true) && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                    Debug.Log("左側");
                }

                //画面右側をタッチした時右フリッパーを動かす
                if ((migi=true) && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                    Debug.Log("右側");
                }

            //タッチを離した瞬間にフリッパーを戻す
            if ((touch.phase == TouchPhase.Ended)&& tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
                hidari = false;
            }
            if ((touch.phase == TouchPhase.Ended)&& tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
                migi = false;
            }

    */
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}