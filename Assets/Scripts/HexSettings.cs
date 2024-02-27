using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexWorld
{ 
    public class HexSettings : MonoBehaviour
    {
        public int hexZoneNumber;  
        public bool isZoneOpen;

        public HexZoneOpenValue hexZoneOpen1;
        public HexZoneOpenValue hexZoneOpen2;
        public HexZoneOpenValue hexZoneOpen3;
        public HexZoneOpenValue hexZoneOpen4;
        public HexZoneOpenValue hexZoneOpen5;
        public HexZoneOpenValue hexZoneOpen6;


        // Start is called before the first frame update
        void Start()
        { 
            hexZoneNumber = gameObject.GetInstanceID();

            hexZoneOpen1.Init();
            hexZoneOpen2.Init();
            hexZoneOpen3.Init();
            hexZoneOpen4.Init();
            hexZoneOpen5.Init();
            hexZoneOpen6.Init();

            if (!isZoneOpen)
            {
                gameObject.SetActive(false);
            }

            if (isZoneOpen)
            {
                CheckZone();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (isZoneOpen)
            {
                CheckZone();
            }
         }

        public void AddGainRes(HexZoneOpenValue zone, int value)
        {
            zone.hexZoneRsurseGained = value;
        }

        void CheckZone()
        {
            if (isZoneOpen)
            {
                hexZoneOpen1.CheckVtoDisable();
                hexZoneOpen2.CheckVtoDisable();
                hexZoneOpen3.CheckVtoDisable();
                hexZoneOpen4.CheckVtoDisable();
                hexZoneOpen5.CheckVtoDisable();
                hexZoneOpen6.CheckVtoDisable();
            }
        }
    }
}
