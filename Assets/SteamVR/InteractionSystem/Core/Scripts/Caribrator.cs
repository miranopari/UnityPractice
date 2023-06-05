using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caribrator : MonoBehaviour
{
    /**
    * CameraRigの位置
    */
    [SerializeField]
    Transform cameraRig;

    /**
    * HMDの目の位置
    */
    [SerializeField]
    Transform hmdEyePos;

    /**
    * モデルの頭の位置 
    */
    [SerializeField]
    Transform modelHeadPos;

    /**
    * 微調整パラメータ
    */
    [SerializeField, Range(-0.5f, 0.5f)]
    float x_offset; //0.01 Unity-ChanのCharacter1_Headを選択したとき

    [SerializeField, Range(-0.5f, 0.5f)]
    float y_offset; //0.03

    [SerializeField, Range(-0.5f, 0.5f)]
    float z_offset; //0.11

    void Update(){
        if(Input.GetKey("c")){
            Calibrate();
        }
    }

    /**
    * キャリブレーション 
    */
    public void Calibrate () {
        float x = modelHeadPos.transform.position.x - hmdEyePos.transform.position.x + x_offset;
        float y = modelHeadPos.transform.position.y - hmdEyePos.transform.position.y + y_offset;
        float z = modelHeadPos.transform.position.z - hmdEyePos.transform.position.z + z_offset;
        cameraRig.position = new Vector3(cameraRig.position.x + x, cameraRig.position.y + y, cameraRig.position.z + z);
        // Debug.Log("y: " + y); 
    }
}
