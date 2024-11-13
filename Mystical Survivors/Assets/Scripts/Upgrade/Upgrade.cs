using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade
{
    public string Name { get; set; }
    public string Description { get; set; }
    public System.Action<PlayerStats> ApplyEffect { get; set; }

    public Upgrade(string name, string description, System.Action<PlayerStats> applyEffect)
    {
        Name = name;
        Description = description;
        ApplyEffect = applyEffect;
    }
}
