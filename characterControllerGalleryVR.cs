using UnityEngine;
using Valve.VR;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class kiosk_VRCharacterController_gallery : MonoBehaviour
{

    [SerializeField]
    Canvas HUDInstructions;

    float verticalVelocity = 0;

    private float timeRemaining = 60.0f;

    CharacterController ng;

    // Use this for initialization
    void Start()
    {

        Cursor.visible = false;
        ng = GetComponent<CharacterController>();

        HUDInstructions.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {

        //falling
        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        Vector3 speed = new Vector3(0, verticalVelocity, 0);
        ng.Move(speed * Time.deltaTime);

        //talk to script checking if controller pad is touched or not
        GameObject leftController = GameObject.Find("left_controller");
        touchpad_inputsForKioskTimeout padInputsLeft = leftController.GetComponent<touchpad_inputsForKioskTimeout>();

        //code for timeout message display follows
        if (padInputsLeft.xPadInput != 0 || padInputsLeft.yPadInput != 0)
        {
            timeRemaining = 60.0f;
            HUDInstructions.enabled = false;
        }
        else
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0)
            {
                HUDInstructions.enabled = true;
            }
        }
    }

}