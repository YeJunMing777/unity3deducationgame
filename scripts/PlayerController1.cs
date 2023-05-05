using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController1 : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 7.0f;
    public float jumpInterval = 2.0f;
    public float interactionDistance = 20.0f;  //interaction component
    private bool isInteracting = false;  //
    public Text interactionText;  // 
    private Rigidbody rb;
    private Vector3 moveDirection;
    private float jumpTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();//movement component
        jumpTimer = jumpInterval;
        interactionText.enabled = false;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
        moveDirection.Normalize();

        jumpTimer += Time.deltaTime;

        if (Input.GetButtonDown("Jump") && jumpTimer >= jumpInterval)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpTimer = 0;
        }
        if (isInteracting)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            interactionText.rectTransform.position = screenPos;
        }
    }
     void LateUpdate()
    {
        if (!isInteracting)
        {
            interactionText.enabled = false;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }


      private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance <= interactionDistance)
            {
                Debug.Log(interactionDistance + "m");
               
                    isInteracting = true;
                    interactionText.enabled = true;
                    // 设置提示文本内容
                    //interactionText.text = "E TO CHAT";
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            isInteracting = false;
        }
    }

    void OnGUI()
    {
        if (isInteracting && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(7);
        }
    }
}
