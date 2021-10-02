using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilityRandom 
{
    public static System.Random Random;



     static UtilityRandom()
    {
        Random = new System.Random();
    }
}
