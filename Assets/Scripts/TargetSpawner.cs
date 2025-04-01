using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject panelPrefab;                      //���� ������(������Ʈ)

    public float generateTime = 3f;                     //����� �ð�

    private float timer = 0;                            //����� �ð� ����� ����

    void Start()
    {
        
    }
  

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;                                        //timer �������� deltaTimde�� ���� ���� �ð� ����

        if (timer <= 0)                                                 //timer�� 0���� �۰ų� ���� ��
        {
            timer = generateTime;                                       //timer�� ����� �ð��� �Է���

            float xPosition = Random.Range(-10f, 10f);                  //-10~10 ������ ������ �Ǽ����� zPosition�� ����
            Vector3 newPos = new Vector3(xPosition, 0, 0);              //������ ���Ӱ� ���� Position ��
            Instantiate(panelPrefab, newPos, Quaternion.identity);      //���� �������� newPos ��ġ�� ������
        }
    }
}
