using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void LateUpdate()
    {
        CamControl();

    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);

    }
}



// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MouseControl : MonoBehaviour{

//     // Adding the enum describing to which direction the following script control
//     [Flags]
//     public enum RotationDirection{
//         None,
//         Horizontal = (1 << 0),
//         Vertical = (1 << 1)
//     }

//     [Tooltip("The direction in which the object should rotate")]
//     [SerializeField] private RotationDirection RotationDirections;
//     [Tooltip("Rotation Acceleration is in degrees per second")]
//     [SerializeField] private Vector2 acceleration;
//     [Tooltip("Multiplier to the input describes the max speed in degrees/second. Flip rotation possible by adding - to the Y value")]
//     [SerializeField] private Vector2 sensitivity;
//     [Tooltip("Max angle form the horizon by which the player rotates, in degrees")]
//     [SerializeField] private float maxVertical_Angle_from_Horizon;
//     [Tooltip("Time to wait until resetting the input value, set as low as possible")]
//     [SerializeField] private float inputLagPeriod;

//     //To pinpoint the camera to keep the player in view
//     public Transform Target, Player;
//     //Rotation velocity in degrees
//     private Vector2 velocity; 
//     //Current Rotation in degrees
//     private Vector2 rotation;
//     //The last non zero input recieved
//     private Vector2 lastInputEvent;
//     //Time since the last non zero value recieved
//     private float inputLagTimer;

//     private float ClampVerticalAngle(float angle){
//         return Mathf.Clamp(angle, -maxVertical_Angle_from_Horizon, maxVertical_Angle_from_Horizon);
//     }

//     private void OnEnable() {
//         //Resetting the State
//         velocity = Vector2.zero;
//         inputLagTimer = 0;
//         lastInputEvent = Vector2.zero;

//         //Calculating the current rotation by getting the Object's local euler angles
//         Vector3 euler = transform.localEulerAngles;
//         //Euler angles required range(-180,180)
//         if(euler.x >= 180){
//             euler.x -= 360;
//         }
//         euler.x = ClampVerticalAngle(euler.x);
//         //Setting angles so that they clamp the current rotation
//         transform.localEulerAngles = euler;
//         //Rotation is stored as [horizontal and vertical] corresponding to the euler agnles around the x and y axis
//         rotation = new Vector2(euler.y, euler.x);
//     }

//     private Vector2 GetInput(){
//         //adding time to the lag timer by deltaTime
//         inputLagTimer += Time.deltaTime;
//         //get the input vactors of X and Y axis
//         Vector2 input = new Vector2(
//             Input.GetAxis("Mouse X"),
//             Input.GetAxis("Mouse Y")
//         );

//         /*...At fast fps, unity will recive inputs of every frame which results in the 0 values of the given inputs,
//         which results in stutter of the mouse movement, and make it hard to finetune the mouse control of the player.
//         To solve this the zero values are discarded. If the lag timerhas passed the lag period, we can assume that the 
//         user is not giving any input, so we want to set the input value to zero at the time. Ultimately, saving the input value
//         if it is a non zero value or the lag timer has met...*/

//         if((Mathf.Approximately(0, input.x) && Mathf.Approximately(0, input.y)) == false || inputLagTimer >= inputLagPeriod) {
//             lastInputEvent = input;
//             inputLagTimer = 0;
//         }
//         return lastInputEvent;
//     }

//     private void Update(){
//         //To look at the player
//         transform.LookAt(Target);

//         //The wanted velocity is scaled by the sensitivity, which is also the ax valocity
//         Vector2 wantedVelocity = GetInput() * sensitivity;

//         //Zeroing out the wanted velocity, the controller does not rotate in that direction
//         if((RotationDirections & RotationDirection.Horizontal) == 0){
//             wantedVelocity.x = 0;
//         }
//         if((RotationDirections & RotationDirection.Vertical) == 0){
//             wantedVelocity.y = 0;
//         }

//         //Calculation of the new rotation
//         velocity = new Vector2(
//             Mathf.MoveTowards(velocity.x, wantedVelocity.x, acceleration.x * Time.deltaTime),
//             Mathf.MoveTowards(velocity.y, wantedVelocity.y, acceleration.y * Time.deltaTime)
//         );
//         rotation += velocity * Time.deltaTime;
//         rotation.y = ClampVerticalAngle(rotation.y);
//         //Conversion of the rotation to euler angles
//         transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
//     }
// }
