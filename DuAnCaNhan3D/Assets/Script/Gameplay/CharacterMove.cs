using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public VariableJoystick joystick;
    public CharacterController controller;
    public float movementSpeed = 5.0f;

    public Canvas inputCanvas;
    public bool isjoyStick;

    public float lastTimeAttack = -1f;
    public float coldownAttack = 1f;

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
    public void Attack()
    {
       if(Time.time >= lastTimeAttack + coldownAttack)
        {
            animator.SetTrigger("attack");
            lastTimeAttack = Time.time;
        }
           
    }  
    public void Jump()
    {
       animator.SetTrigger("jump");
       
    }
  
}
