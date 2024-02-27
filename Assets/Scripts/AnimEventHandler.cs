using HexWorld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class AnimEventHandler : MonoBehaviour
{
    [SerializeField] private GameObject colliderGO;
    [SerializeField] private PlayerController playerControl;
    [SerializeField] private GameObject axe;
    [SerializeField] private GameObject crutch;
    public UnityAction <ResourceType> SetAttackType;
    [SerializeField] private ResourceType atackResType; 
    Animator anim;
    float time = 0;
    void Awake()
    {
        playerControl = GetComponentInParent<PlayerController>();
        anim = GetComponent<Animator>();
        SetAttackType += SetResType; 
    }

    void SetResType(ResourceType atackRes)
    {
        atackResType = atackRes;
    } 
    public void OnBeginAttack(){ SetTool(); }
    public void OnEndAttack() { DeactivateTool(); }
    public void OnEnableHitBox() { colliderGO.SetActive(true); }
    public void OnDisableHitBox() { colliderGO.SetActive(false); }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void SetTool()
    {
        if (atackResType == ResourceType.Wood)
        {
            axe.SetActive(true);
            crutch.SetActive(false);
        }else
        if (atackResType == ResourceType.Stone)
        {
            axe.SetActive(false);
            crutch.SetActive(true);
        }else
        {
            axe.SetActive(false);
            crutch.SetActive(false);
        }
    }
    private void DeactivateTool()
    {
        axe.SetActive(false);
        crutch.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(colliderGO.activeSelf)
        {
            time += Time.deltaTime;
            if (time > playerControl.resourseManager.resourseConsumeTime)
            {
                time = 0;
            
                RaycastHit[] hit = Physics.BoxCastAll(colliderGO.transform.position, colliderGO.GetComponent<BoxCollider>().size/2, Vector3.forward, Quaternion.identity, 0.1f);

                foreach (var item in hit)
                {
                    //Debug.Log("Hit " + item.collider.gameObject.name);
                    if (item.collider.gameObject.tag == "Resource")
                    {
                        playerControl.resourseManager.GetResorse(item.collider.gameObject.GetComponent<ResLoot>().resType, 1);
                        item.collider.gameObject.GetComponent<ResLoot>().ResurseConsume(1);
                    } 
                }
            }
        }
    }   
}
