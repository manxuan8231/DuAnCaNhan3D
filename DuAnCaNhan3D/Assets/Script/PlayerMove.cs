using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public VariableJoystick joystick;
    public CharacterController characterController;
    public Canvas inputCanvas;
    public bool isJoystick;

    //speed player
    public float moveSpeed = 0;
    public float rotationSpeed = 0;

    void Start()
    {
        EnableJoystickInput();
        
    }

    public void EnableJoystickInput()
    {
        isJoystick = true;
        inputCanvas.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if(isJoystick)
        {
            var moveDirection = new Vector3(joystick.Direction.x, 0.0f, joystick.Direction.y);
            characterController.Move(moveDirection * moveSpeed);
            if(moveDirection.sqrMagnitude <= 0)
            {
                return;
            }
            var targetDirection = Vector3.RotateTowards(characterController.transform.forward, moveDirection, rotationSpeed * Time.deltaTime, 0.0f);
            characterController.transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }
}
