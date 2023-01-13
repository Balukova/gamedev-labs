using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonMovement : MonoBehaviour
{
    public GameObject person;
    public CharacterController characterController;
    public float speed = 10f;
    public float jumpSpeed = 10f;
    public float gravity = 10f;
    private Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection.x = horizontal;
        moveDirection.y -= gravity * Time.deltaTime; ;
        moveDirection.z = vertical;

        if (moveDirection.magnitude >= 0.1f)
        {
            float angle = Mathf.Atan2(moveDirection.x, moveDirection.z)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            characterController.Move(moveDirection * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveDirection.y = jumpSpeed;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Object.DontDestroyOnLoad(person);
            SceneManager.LoadScene("Scene2");
        }

    }
}
