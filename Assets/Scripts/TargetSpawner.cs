using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject panelPrefab;                      //과녁 프리팹(오브젝트)

    public float generateTime = 3f;                     //재생성 시간

    private float timer = 0;                            //재생성 시간 저장용 변수

    void Start()
    {
        
    }
  

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;                                        //timer 변수에서 deltaTimde을 빼서 지간 시간 측정

        if (timer <= 0)                                                 //timer가 0보다 작거나 같을 때
        {
            timer = generateTime;                                       //timer에 재생성 시간을 입력함

            float xPosition = Random.Range(-10f, 10f);                  //-10~10 사이의 랜덤한 실수값을 zPosition에 대입
            Vector3 newPos = new Vector3(xPosition, 0, 0);              //과녁이 새롭게 생길 Position 값
            Instantiate(panelPrefab, newPos, Quaternion.identity);      //과녁 프리팹을 newPos 위치에 생성함
        }
    }
}
