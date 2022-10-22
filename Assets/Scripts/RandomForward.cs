using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForward : MonoBehaviour
{
    

    // Start is called before the first frame update
    private bool xz_forward=false;//xzの平面に進んでいるかどうか
    private bool y_forward=false;//y軸方向に進んでいるかどうか
    private float step=0.01f;//1フレームにどれだけシャボン玉が進むか(シャボン玉の速度に直接関係する)
    private float max_step=10;//一度に進む最大距離
    private float theta;//xz平面に進方向の極座標の角度
    private float r;//xz平面に進方向の極座標の半径
    private float h;//y軸方向に進む値
    private float hmax=52.0f;//シャボン玉が動ける高さの最大
    private float hmin=22.0f;//シャボン玉が動ける高さの最小
    private bool UpState=true;//y軸方向に上がっているか下がっているか
    

    // Update is called once per frame
    void Update()
    {
        if(!xz_forward){//xz方向に進む方向と距離を決める
            xz_forward=true;
            //極座標使う
            theta=Random.Range(0,360);
            r=Random.Range(0,max_step);
            

        }
        /*
        if(!y_forward){//y方向に進む距離を決める
            y_forward=true;
            h=Random.Range(-max_step,max_step);
            if(h<0){
                UpState=false;//y方向に下がっている状態
            }else{
                UpState=true;
            }
        }
        */

        //距離の更新
        //xz平面の更新
        transform.position+=new Vector3(step*Mathf.Cos(theta*Mathf.Deg2Rad),0,step*Mathf.Sin(theta*Mathf.Deg2Rad));
        r=r-step;
        //y軸の更新
        /*
        if(h>=0){//hが正であるとき、シャボン玉は上方向に更新される
            transform.position+=new Vector3(0,step,0);
            if(transform.position.y>hmax && UpState){//シャボン玉が高さ上限を超えていたら
                h*=-1;//正負反転
                UpState=false;
                h=h+step;
            }
            else{
                h=h-step;
            }
        }else{//hが負であるとき、シャボン玉は下方向に更新される
            transform.position+=new Vector3(0,-step,0);
            if(transform.position.y<hmin && !UpState){//シャボン玉が高さ下限を下回っていたら
                h*=-1;//正負反転
                UpState=true;
                h=h-step;
            }
            else{
                h=h+step;
            }
        }*/


        if(r<=0){//r方向に進み切っていたら
            xz_forward=false;
        }
        /*
        if(h<=0){//h分進み切った場合
            y_forward=false;
        }
        */
    }
}
