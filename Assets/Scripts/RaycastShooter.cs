using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaycastShooter : MonoBehaviour
{
    public ParticleSystem flashEffect;                      //�߻� ����Ʈ ���� ����

    //źâ ���� ���� ����
    public int magazineCapacity = 30;                       //źâ�� ũ��
    private int currentAmmo;                                //���� �Ѿ� ����

    public TextMeshProUGUI ammoUI;                          //�Ѿ� ������ ��Ÿ�� TextMeshProUGUI ����

    //������ ��� ���� ����
    public Image reloadingUI;                               //������ UI
    public float reloadTime = 2f;                           //������ �ð�
    private float timer = 0;                                //�ð� Ȯ�ο� Ÿ�̸�
    private bool isReloading = false;                       //������ Ȯ�ο� bool ����

    //���� ��� ��� ���� ����
    public AudioSource audioSource;                         //����� �ҽ�
    public AudioClip audioClip;                             //����� Ŭ��

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = magazineCapacity;                     //���� �Ѿ��� ������ źâ�� ũ�⸸ŭ���� ����
        //ammoUI.text = currentAmmo + "/" + magazineCapacity;
        ammoUI.text = $"{currentAmmo}/{magazineCapacity}";      //���� �Ѿ� ������ UI�� ǥ��

        reloadingUI.gameObject.SetActive(false);                //������ UI ��Ȱ��ȭ
     }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && currentAmmo > 0 && isReloading == false)                      //���������� �ƴҶ� ���� �߰�
        {
            audioSource.PlayOneShot(audioClip);             //�߻� ���� ���
            currentAmmo--;                                  //�Ѿ��� 1�� �Һ��Ѵ�.
            flashEffect.Play();                             //����Ʈ ���
            ammoUI.text = $"{currentAmmo}/{magazineCapacity}";      //���� �Ѿ� ������ UI�� ǥ�� (�Ѿ� �Һ� �� ǥ��!!!)
            ShootRay();
        }

        if(Input.GetKeyDown(KeyCode.R))                     //RŰ�� ������
        {
            isReloading = true;                             //������ ������ ����
            reloadingUI.gameObject.SetActive(true);         //������ UI Ȱ��ȭ
        }

        if(isReloading == true)
        {
            Reloading();
        }
    }

    void ShootRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Destroy(hit.collider.gameObject);
        }
    }

    void Reloading()
    {
        timer += Time.deltaTime;

        reloadingUI.fillAmount = timer / reloadTime;                    //������ UI�� fill ���� ���� ������� ������Ʈ

        if(timer >= reloadTime)                                         //������ �ð��� ������ ���
        {
            timer = 0;
            isReloading = false;                                        //�������� �Ϸ� ������ ǥ��
            currentAmmo = magazineCapacity;                             //�Ѿ��� ä���ش�.
            ammoUI.text = $"{currentAmmo}/{magazineCapacity}";          //���� �Ѿ� ������ ǥ��
            reloadingUI.gameObject.SetActive(false);                    //������ UI ������Ʈ�� ��Ȱ��ȭ
        }
    }
}
