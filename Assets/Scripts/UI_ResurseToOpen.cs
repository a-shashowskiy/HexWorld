using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HexWorld
{
    public class UI_ResurseToOpen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI gainedValue;
        [SerializeField] private Image resourseImage;
        [SerializeField] private Sprite wood;
        [SerializeField] private Sprite stone;
        [SerializeField] private Sprite iron;
        [SerializeField] private Sprite gems;
        [SerializeField] private Sprite plank;
        int needResValue;

        // Start is called before the first frame update
        public void Init(ResourceType rt, int gainedV, int resNeed)
        {
            needResValue = resNeed;
            switch (rt)
            {
                case ResourceType.Wood:
                    resourseImage.sprite = wood;
                    break;
                case ResourceType.Stone:
                    resourseImage.sprite = stone;
                    break;
                case ResourceType.Iron:
                    resourseImage.sprite = iron;
                    break;
                case ResourceType.Gems:
                    resourseImage.sprite = gems;
                    break;
                case ResourceType.Lambert:
                    resourseImage.sprite = plank;
                    break;
            }
            gainedValue.text = gainedV.ToString() + "\n-\n" + needResValue.ToString();
        }

         public void UpdateResurse(int resValue)
        {
            gainedValue.text = resValue.ToString()+"\n-\n"+ needResValue.ToString();
        }
    }
}
