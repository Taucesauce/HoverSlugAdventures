using UnityEngine;
using System.Collections;

namespace Assets.Scripts.ObjectScripts
{
    public class LargeGrid : Grid
    { 
        protected override void Awake()
        {
            base.Awake();
            this.gridWidth = 8;
            this.gridHeight = 8;
        }
    }
}