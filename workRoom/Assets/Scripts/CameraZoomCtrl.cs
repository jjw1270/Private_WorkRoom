using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomCtrl : MonoBehaviour
{
    private Camera cam;
    [SerializeField]private float minOrthoSize = 3.5f;
    [SerializeField]private float maxOrthoSize = 5f;
    [Space (10f)]

    [Header ("for pc test")]
    public float zoomSpeed = 10.0f;
    private float tempSize;
    [Space(10f)]

    [Header ("for mobile")]
    [SerializeField]private float orthoZoomSpeed = 0.5f;
    
    private void Start() {
        cam = GetComponent<Camera>();
    }
    void Update()
    {
        MouseWheelZoom();
        TouchZoom();
    }

    //on PC
    void MouseWheelZoom(){
        float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        //scroll down 시 줌 인
        if(cam.orthographicSize <= minOrthoSize && scroll > 0){
            tempSize = cam.orthographicSize;
            cam.orthographicSize = tempSize;  //maximize zoom in
        }
        else if(cam.orthographicSize >= maxOrthoSize && scroll < 0){
            tempSize = cam.orthographicSize;
            cam.orthographicSize =  tempSize;
        }
        else{
            cam.orthographicSize -= scroll * 0.05f;
        }
    }

    //on Mobile
    void TouchZoom(){
        if(Input.touchCount == 2){
            Touch touchZero = Input.GetTouch(0);   //첫 번째 터치
            Touch touchOne = Input.GetTouch(1);   //두 번째 터치

            //터치에 대한 이전 위치값 각각 저장
            //처음 터치한 위치에서 이전 프레임에서의 터치위치 - 이번 프레임에서 터치 위치
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            //각 프레임에서 터치 사이의 벡터 거리 계산
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            cam.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed * Time.deltaTime * 0.1f;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minOrthoSize, maxOrthoSize);
        }
    }
}
