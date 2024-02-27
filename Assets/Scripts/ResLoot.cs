using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexWorld
{
    public class ResLoot : MonoBehaviour
    {
        public ResourceType resType;
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private int resValue; // How much resources can be gained from this loot
        [SerializeField] private int resConsume; // How much resources consumed
        [SerializeField] private float restoreTime = 50.0f; // How much time to restore resources
        [SerializeField] float partRestoreTime = 25.0f;
        [SerializeField] private List<GameObject> consumeVisPart;
        [SerializeField] private ParticleSystem consumeVFX;
       
        public int AviableResValue { get { return resValue - resConsume; } }
        float time = 0;
        float partRestoreTimer = 0;
       

        public void Start()
        {
            resConsume = 0;
            boxCollider = GetComponent<BoxCollider>();
            foreach (var item in consumeVisPart)
            {
                item.SetActive(true);
            }
        }

        public void Update()
        {
            VisConsume();
            if(AviableResValue == 0)
            { 
                time += Time.deltaTime;
                if (time >= restoreTime)
                {
                    RestoreVis(); 
                    resConsume = 0;
                    time = 0;
                }
            }
            else
            {
                partRestoreTimer += Time.deltaTime;
                if (partRestoreTimer >= partRestoreTime)
                {
                    RestoreVis(); 
                    resConsume = 0;
                    time = 0;
                }
            } 
        }

        public void ResurseConsume(int value)
        {
            if(AviableResValue == 0) return;
            resConsume += value;
            partRestoreTimer = 0;
            if(!consumeVFX.isPlaying) consumeVFX.Play();
            if (resConsume > resValue)
            {
                resConsume = resValue;
            }
        }

        void VisConsume()
        {
            int part = resValue / consumeVisPart.Count;

            for(int i = consumeVisPart.Count;i>=0 ; i--)
            {
                if (resConsume >= part * (i + 1))
                {
                    consumeVisPart[i].SetActive(false);
                }
            }
        } 

        void RestoreVis()
        {
            foreach (var item in consumeVisPart)
            {
                item.SetActive(true);
            }
        }
    }
}
