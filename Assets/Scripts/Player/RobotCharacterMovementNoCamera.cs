using UnityEngine;

// WASD to move, Space to sprint
public class RobotCharacterMovementNoCamera : MonoBehaviour
{
    public Transform InvisibleCameraOrigin;

    public float StrafeSpeed = 0.1f;
    public float MoveSpeed = 0.5f;
    public float TurnSpeed = 3;
    public float Damping = 0.2f;
    public float VerticalRotMin = -80;
    public float VerticalRotMax = 80;
    public KeyCode sprintJoystick = KeyCode.JoystickButton2;
    public KeyCode sprintKeyboard = KeyCode.Space;

    // private bool isSprinting;
    private Animator anim;
    private float currentStrafeSpeed;
    private Vector2 currentVelocity;

    RobotPieces m_robotPieces;
    

    bool isIdle = true;
    int pieces = 5;

    // Start is called before the first frame update
    void Start()
    {
        m_robotPieces = GetComponent<RobotPieces>();

        if(m_robotPieces == null) {
            Debug.Log("RobotCharacterMovementNoCamera: No se encontro el componente RobotPieces");
        }

    }


    void OnEnable()
    {
        anim = GetComponent<Animator>();
        currentVelocity = Vector2.zero;
        currentStrafeSpeed = 0;
        // isSprinting = false;
    }

    void FixedUpdate()
    {
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var speed = input.y;
        speed = Mathf.Clamp(speed, -1f, 1f);
        speed = Mathf.SmoothDamp(anim.GetFloat("Speed"), speed, ref currentVelocity.y, Damping);
        // Go slower when fewer pieces
        float piecesFactor = ((float)(pieces + 5)/ 10f);
        speed *= MoveSpeed * piecesFactor;
        anim.SetFloat("Speed", speed);
        anim.SetFloat("Direction", speed);


        // set sprinting
        // isSprinting = (Input.GetKey(sprintJoystick) || Input.GetKey(sprintKeyboard)) && speed > 0;
        //anim.SetBool("isSprinting", isSprinting);


        // isIdle = ! (Input.GetKey(sprintJoystick) || Input.GetKey(sprintKeyboard)) && speed > 0;
        
        {
            pieces = 1; // head
            if (RobotPieces.hasHipAndRightFoot) pieces ++;
            if (RobotPieces.hasLeftFoot) pieces ++;
            if (RobotPieces.hasChestAndRightArm) pieces ++;
            if (RobotPieces.hasLeftArm) pieces ++;
        }

        /*
        if ( Input.GetKey(sprintKeyboard) ) {
            pieces = (pieces + 1) % 5 + 1;
        }*/
        if ( Input.GetKey(KeyCode.Keypad1) ) {
            pieces = 1;
        }
        if ( Input.GetKey(KeyCode.Keypad2) ) {
            pieces = 2;
        }

        if ( Input.GetKey(KeyCode.Keypad3) ) {
            pieces = 3;
        }
        if ( Input.GetKey(KeyCode.Keypad4) ) {
            pieces = 4;
        }
        if ( Input.GetKey(KeyCode.Keypad5) ) {
            pieces = 5;
        }


        

        isIdle = input.y == 0;
        Debug.Log(speed.ToString());

        anim.SetBool("isIdle", isIdle);
        anim.SetInteger("pieces", pieces);

        // move
        transform.position += transform.TransformDirection(Vector3.forward) * speed;

        // strafing
        currentStrafeSpeed = Mathf.SmoothDamp(
            currentStrafeSpeed, input.x * StrafeSpeed, ref currentVelocity.x, Damping);
        transform.position += transform.TransformDirection(Vector3.right) * currentStrafeSpeed;

        var rotInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        var rot = transform.eulerAngles;
        rot.y += rotInput.x * TurnSpeed;
        transform.rotation = Quaternion.Euler(rot);

        if (InvisibleCameraOrigin != null)
        {
            rot = InvisibleCameraOrigin.localRotation.eulerAngles;
            rot.x -= rotInput.y * TurnSpeed;
            if (rot.x > 180)
                rot.x -= 360;
            rot.x = Mathf.Clamp(rot.x, VerticalRotMin, VerticalRotMax);
            InvisibleCameraOrigin.localRotation = Quaternion.Euler(rot);
        }
    }
}
