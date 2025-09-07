using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public VariableJoystick joystick;
    public CharacterController controller;
    public float movementSpeed = 5.0f;

    public Canvas inputCanvas;
    public bool isjoyStick;

    public Animator animator; 
    private void Start()
    {       
        EnableJoyStickInput();     
    }
    public void EnableJoyStickInput()
    {
        isjoyStick = true;
        //joystick.gameObject.SetActive(true);
        inputCanvas.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (isjoyStick)
        {
            var movementDirection = new Vector3(joystick.Direction.x, 0.0f, joystick.Direction.y);
            controller.SimpleMove(movementDirection * movementSpeed);

            //xoay nhan vat theo huong di chuyen
            if (movementDirection.sqrMagnitude <= 0) 
            { 
                animator.SetBool("isRuning",false);
                return;
             }//khong di chuyen thi ko xoay
            animator.SetBool("isRuning", true);
            var targetDirection = Vector3.RotateTowards(controller.transform.forward, movementDirection, movementSpeed * Time.deltaTime, 0.0f);
            controller.transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }
}
