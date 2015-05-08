using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.ObjectScripts
{
    public class LargeGrid : Grid
    { 
        protected override void Awake()
        {
            this.gridWidth = 8;
            this.gridHeight = 8;
            switchList = new List<Tile>();
            teleportSound = GetComponent<AudioSource>();
        }
    }
}