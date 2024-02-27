using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexWorld
{
    public class UI_Resuorse : MonoBehaviour
    {
        [SerializeField] private GameObject woodPanel;
        [SerializeField] private GameObject stonePanel;
        [SerializeField] private GameObject ironPanel;
        [SerializeField] private GameObject gemsPanel;
        [SerializeField] private GameObject lambertPanel;
        [SerializeField] private TMPro.TextMeshProUGUI wood;
        [SerializeField] private TMPro.TextMeshProUGUI stone;
        [SerializeField] private TMPro.TextMeshProUGUI iron;
        [SerializeField] private TMPro.TextMeshProUGUI gems;
        [SerializeField] private TMPro.TextMeshProUGUI lambert;

        public void UpdateUIValue(ResourceType rt, int value)
        { 
            switch (rt)
            {
                case ResourceType.Wood:  
                    if(value > 0)
                    {
                        woodPanel.SetActive(true);
                    }
                    else
                    {
                        woodPanel.SetActive(false);
                    }
                    wood.text = value.ToString();
                    break;
                case ResourceType.Stone:
                    if (value > 0)
                    {
                        stonePanel.SetActive(true);
                    }
                    else
                    {
                        stonePanel.SetActive(false);
                    }
                    stone.text = value.ToString();
                    break;
                case ResourceType.Iron:
                    if (value > 0)
                    {
                        ironPanel.SetActive(true);
                    }
                    else
                    {
                        ironPanel.SetActive(false);
                    }
                    iron.text = value.ToString();
                    break;
                case ResourceType.Gems:
                    if (value > 0)
                    {
                        gemsPanel.SetActive(true);
                    }
                    else
                    {
                        gemsPanel.SetActive(false);
                    }
                    gems.text = value.ToString();
                    break;
                case ResourceType.Lambert:
                    if (value > 0)
                    {
                        lambertPanel.SetActive(true);
                    }
                    else
                    {
                        lambertPanel.SetActive(false);
                    }
                    lambert.text = value.ToString();
                    break;
            }
        }
    } 
}
