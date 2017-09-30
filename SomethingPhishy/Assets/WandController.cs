using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    public bool gripButtonDown = false;
    public bool gripButtonUp = false;
    public bool gripButtonPressed = false;


    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
    public bool triggerButtonPressed = false;



    //Creates a read only value for the tracked object to determine what controller is at which index
    //In layman's speak, what controller is in what hand.
    //The trackObj is the variable that determines which object is being tracked now.
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    // Use this for initialization
    //Begins script by retrieving the trackedObj component and get index values
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    //This function is an "always-listening" function
    //This one determines whether a grip button or trigger was pressed and unpressed
    //Variables and methods are self-explanatory
    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        gripButtonDown = controller.GetPressDown(gripButton);
        gripButtonUp = controller.GetPressUp(gripButton);
        gripButtonPressed = controller.GetPress(gripButton);

        triggerButtonDown = controller.GetPressDown(triggerButton);
        triggerButtonUp = controller.GetPressUp(triggerButton);
        triggerButtonPressed = controller.GetPress(triggerButton);

        if (gripButtonDown)
        {
            Debug.Log("Grip Button was just pressed");
        }
        if (gripButtonUp)
        {
            Debug.Log("Grip Button was just unpressed");
        }
        if (triggerButtonDown)
        {
            Debug.Log("Trigger Button was just pressed");
        }
        if (triggerButtonUp)
        {
            Debug.Log("Trigger Button was just unpressed");
        }
    }



}
