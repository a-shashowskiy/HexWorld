using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
namespace HexWorld
{
    public class ResourseManager : MonoBehaviour
    {
        public UI_Resuorse uiResourse;

        public int resourseWood;
        public int resourseStone;
        public int resourseGems;
        public int resourseLambert;
        public int resourseIron;
        public float resourseConsumeTime = 1f;

        void Start()
        {
            uiResourse.UpdateUIValue(ResourceType.Wood, resourseWood);
            uiResourse.UpdateUIValue(ResourceType.Stone, resourseStone);
            uiResourse.UpdateUIValue(ResourceType.Iron, resourseIron);
            uiResourse.UpdateUIValue(ResourceType.Gems, resourseGems);
            uiResourse.UpdateUIValue(ResourceType.Lambert, resourseLambert);
        }

        public void GetResorse(ResourceType rt, int value)
        {
            switch (rt)
            {
                case ResourceType.Wood:
                    resourseWood += value;
                    uiResourse.UpdateUIValue(ResourceType.Wood, resourseWood);
                    break;
                case ResourceType.Stone:
                    resourseStone += value;
                    uiResourse.UpdateUIValue(ResourceType.Stone, resourseStone);
                    break;
                case ResourceType.Iron:
                    resourseIron += value;
                    uiResourse.UpdateUIValue(ResourceType.Iron, resourseIron);
                    break;
                case ResourceType.Gems:
                    resourseGems += value;
                    uiResourse.UpdateUIValue(ResourceType.Gems, resourseGems);
                    break;
                case ResourceType.Lambert:
                    resourseLambert += value;
                    uiResourse.UpdateUIValue(ResourceType.Lambert, resourseLambert);
                    break;
            } 
        }

        public void LoseResource(ResourceType rt, int value)
        {
            //Debug.Log("LoseResource");

            switch (rt)
            {
                case ResourceType.Wood:
                    if(resourseWood - value >= 0 )resourseWood -= value;
                    else resourseWood = 0;
                    uiResourse.UpdateUIValue(ResourceType.Wood, resourseWood);
                    break;
                case ResourceType.Stone:
                    if(resourseStone - value >= 0)resourseStone -= value;
                    else resourseStone = 0;
                    uiResourse.UpdateUIValue(ResourceType.Stone, resourseStone);
                    break;
                case ResourceType.Iron:
                    if(resourseIron-value >= 0)resourseIron -= value;
                    else resourseIron = 0;
                    uiResourse.UpdateUIValue(ResourceType.Iron, resourseIron);
                    break;
                case ResourceType.Gems:
                    if(resourseGems-value >= 0)resourseGems -= value;
                    else resourseGems = 0;
                    uiResourse.UpdateUIValue(ResourceType.Gems, resourseGems);
                    break;
                case ResourceType.Lambert:
                    if(resourseLambert-value >= 0)resourseLambert -= value;
                    else resourseLambert = 0;
                    uiResourse.UpdateUIValue(ResourceType.Lambert, resourseLambert);
                    break;
            }
            
        }
    }
}