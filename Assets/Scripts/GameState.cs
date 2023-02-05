using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public bool sphereRemoved;

    public bool[] triggered;

    public GameState() {
        sphereRemoved = false;
        triggered = new bool[]{true, false, false, false, false, false, false, false, false, false };
    }
}
