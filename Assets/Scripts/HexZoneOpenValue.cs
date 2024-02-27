using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexWorld
{
    [System.Serializable]
    public class HexZoneOpenValue
    {
        public bool active;
        public bool zonesIsOpen { get; set; }
        public GameObject hexZone;
        public int hexZoneOpenValue;
        public int hexZoneRsurseGained;
        public ResourceType hexZoneRsourseType;
        public List<HexSettings> nextHexZone = new List<HexSettings>();
        public bool deactiveToOpen = false; 
        [SerializeField] private UI_ResurseToOpen uiResurseToOpen;

        public void Init()
        {
            uiResurseToOpen.Init(hexZoneRsourseType, hexZoneRsurseGained, hexZoneOpenValue);
        }

        public void GetResurse(int resValue)
        {
            hexZoneRsurseGained += resValue;  
            uiResurseToOpen.UpdateResurse(hexZoneRsurseGained);
        }

        public void CheckVtoDisable()
        {
            //Debug.Log("CheckVtoDisable. Gained resources = " + hexZoneRsurseGained);
            if (!active) hexZone.SetActive(false);
            if(zonesIsOpen) return;

            if (hexZoneOpenValue == hexZoneRsurseGained)
            {
                zonesIsOpen = true;
                if (nextHexZone != null)
                {
                    hexZone.SetActive(false);
                    foreach (var item in nextHexZone)
                    {
                        if (item != null)
                        {
                            if (deactiveToOpen)
                            {
                                item.gameObject.SetActive(false);
                            }
                            else
                            {
                                item.gameObject.SetActive(true);
                                item.isZoneOpen = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
