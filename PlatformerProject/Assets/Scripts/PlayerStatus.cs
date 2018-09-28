using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus {
    public enum States
    {
        Solid,
        Gas,
        Dead,
    }
    public static States physicalState;
    //Listens for input  and functions that lock and unlock states. Static functions
    private static bool locked = false;

    public static void SwitchStates() {
        if (physicalState == PlayerStatus.States.Solid) {
            physicalState = PlayerStatus.States.Gas;
        }
        else {
            physicalState = PlayerStatus.States.Solid;
        }
    }

    public static void SetToState(States newState) {
        physicalState = newState;
    }

    public static bool StateLocked() {
        return locked;
    }

    public static void LockSwitch()
    {
        //prevent player from switching states
        locked = true;
    }

    public static void UnlockSwitch()
    {
        //unlock ability to switch states
        locked = false;
    }

}
