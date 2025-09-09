using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class ITEMSO : ScriptableObject
{
    public string itemName;
    [TextArea] public string itenDescription;
    public Sprite icon;

}