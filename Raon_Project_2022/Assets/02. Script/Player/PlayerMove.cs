using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float turnSpeed = 4.0f; // ���콺 ȸ�� �ӵ�
    public float moveSpeed = 10.0f; // �̵� �ӵ�

    private float xRotate = 0.0f; // ���� ����� X�� ȸ������ ���� ���� ( ī�޶� �� �Ʒ� ���� )
    InputManager input;

    private void Start()
    {
        input = GameObject.Find("InputManager").GetComponent<InputManager>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        MouseRotation();
        KeyboardMove(); 
        DishInteraction();
    }

    // ���콺�� �����ӿ� ���� ī�޶� ȸ�� ��Ų��.
    void MouseRotation()
    {
        // �¿�� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� �¿�� ȸ���� �� ���
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        // ���� y�� ȸ������ ���� ���ο� ȸ������ ���
        float yRotate = Camera.main.transform.eulerAngles.y + yRotateSize;

        // ���Ʒ��� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� ȸ���� �� ���(�ϴ�, �ٴ��� �ٶ󺸴� ����)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ���� (-45:�ϴù���, 80:�ٴڹ���)
        // Clamp �� ���� ������ �����ϴ� �Լ�
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        // ī�޶� ȸ������ ī�޶� �ݿ�(X, Y�ุ ȸ��)
        Camera.main.transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }

    // Ű������ ������ ���� �̵�
    void KeyboardMove()
    {
        Vector3 move =
            Camera.main.transform.forward * Input.GetAxisRaw("Vertical") +
            Camera.main.transform.right * Input.GetAxisRaw("Horizontal");

        move = new Vector3(move.x, 0, move.z).normalized;

        // �̵����� ��ǥ�� �ݿ�
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    GameObject grabObject;
    public GameObject grabPos;
    bool isGrab = false;
    void DishInteraction()
    {
        if (input.Interaction)
        {
            Ray ray;
            RaycastHit hit;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 10f) && !isGrab)
            {
                if (hit.collider.gameObject.CompareTag("Dish") || hit.collider.gameObject.CompareTag("Food"))
                {
                    grabObject = hit.collider.gameObject;
                    grabObject.GetComponent<Rigidbody>().isKinematic = true;
                    grabObject.GetComponent<BoxCollider>().enabled = false;
                    grabObject.transform.parent = grabPos.transform;
                    grabObject.transform.localPosition = Vector3.zero;
                    grabObject.transform.localRotation = Quaternion.identity;
                    isGrab = true;
                }
            }
        }
        else if(isGrab)
        {
            isGrab = false;
            grabObject.GetComponent<Rigidbody>().isKinematic = false;
            grabObject.GetComponent<BoxCollider>().enabled = true;
            grabObject.transform.parent = null;
            grabObject = null;
        }
    }
}