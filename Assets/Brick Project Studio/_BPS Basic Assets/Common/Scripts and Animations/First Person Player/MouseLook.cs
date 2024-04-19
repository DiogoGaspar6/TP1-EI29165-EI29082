using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
    public class MouseLook : MonoBehaviour
    {

        public float mouseXSensitivity = 60f;

        public Transform playerBody;

        float xRotation = 0f;

        public GameObject crosshair;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
        }

        // Update is called once per frame
        void Update()
        {
    
            float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseXSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);

            if(Cursor.lockState == CursorLockMode.None && Cursor.visible == false){
                crosshair.SetActive(true);
                Cursor.visible = true;
            }else if (Cursor.lockState == CursorLockMode.Locked && Cursor.visible == true) { 
                crosshair.SetActive(false); 
                Cursor.visible = false; 
            } 
        } 
    } 
}
