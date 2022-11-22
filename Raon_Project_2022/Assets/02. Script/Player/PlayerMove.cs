using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float turnSpeed = 4.0f; // 마우스 회전 속도
    public float moveSpeed = 10.0f; // 이동 속도

    private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 ( 카메라 위 아래 방향 )
    InputManager input;

    AudioSource _audioSource;
    public AudioClip popSound;

    CharacterController _characterController;

    float yPos;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _characterController = GetComponent<CharacterController>();
        input = GameObject.Find("InputManager").GetComponent<InputManager>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        yPos = transform.position.y;
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        MouseRotation();
        KeyboardMove(); 
        DishInteraction();
    }

    // 마우스의 움직임에 따라 카메라를 회전 시킨다.
    void MouseRotation()
    {
        // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        // 현재 y축 회전값에 더한 새로운 회전각도 계산
        float yRotate = Camera.main.transform.eulerAngles.y + yRotateSize;

        // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
        // Clamp 는 값의 범위를 제한하는 함수
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
        Camera.main.transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }

    // 키보드의 눌림에 따라 이동
    void KeyboardMove()
    {
        Vector3 move =
            Camera.main.transform.forward * Input.GetAxisRaw("Vertical") +
            Camera.main.transform.right * Input.GetAxisRaw("Horizontal");

        move = new Vector3(move.x, 0, move.z).normalized;

        // 이동량을 좌표에 반영
        _characterController.Move(move * moveSpeed * Time.deltaTime);
        //transform.position += move * moveSpeed * Time.deltaTime;
    }

    GameObject grabObject;
    public GameObject grabPos;
    bool isGrab = false;

    float timer = 0f;
    void DishInteraction()
    {
        timer += Time.deltaTime;
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

                    if (hit.collider.GetComponent<CookingMeat>())
                    {
                        hit.collider.GetComponent<CookingMeat>().isCooking = false;
                    }

                }

                if (hit.collider.CompareTag("Customer"))
                {
                    // output customer's order to screen
                    hit.collider.GetComponent<CustomerMove>().TableDestination();
                }

                if (hit.collider.CompareTag("Dispenser") && timer > 0.2f)
                {
                    timer = 0f;
                    hit.collider.GetComponent<FoodDispenser>().SpawnPrefab();
                    _audioSource.PlayOneShot(popSound);
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