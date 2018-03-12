using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AvailableState {
    public abstract bool GetAvail();
    public abstract void SetAvail(bool stateAvail);
    public abstract void ResetTime();
}
