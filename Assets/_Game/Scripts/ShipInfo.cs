using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ship Info", fileName = "ShipInfo", order = 0)]
public class ShipInfo : ScriptableObject
{
    public float throttleSpeed;
    public float rotationSpeed;

    public int health;
}
