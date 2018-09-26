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
    private static bool locked;

    public static void SwitchStates() {
        
    }

    public static void SetToState(States newState) {
        physicalState = newState;
    }

    public static void LockSwitch()
    {

    }

    public static void UnlockSwitch()
    {

    }
}
