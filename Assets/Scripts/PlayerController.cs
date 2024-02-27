using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

namespace HexWorld
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 5.0f;
        [SerializeField] private DynamicJoystick _joystick;
        [SerializeField] private Animator _animator;
        [SerializeField] private ResourseManager _resourseManager;
        [SerializeField] private AnimEventHandler _animEventHandler;
        [SerializeField] HexSettings curentZone;
        public Rigidbody rb { get; set; }
        public CapsuleCollider playerCollider { get; set; }
        public ResourseManager resourseManager { get { return _resourseManager; } }
        // Start is called before the first frame update
        void Start()
        {
            playerCollider = GetComponent<CapsuleCollider>();
            rb = GetComponent<Rigidbody>();
            _resourseManager = GetComponent<ResourseManager>();
            _joystick = FindObjectOfType<DynamicJoystick>();
            _animator = GetComponentInChildren<Animator>();
            _animEventHandler = _animator.GetComponent<AnimEventHandler>();
        }

        // Update is called once per frame
        void Update()
        {
            curentZone = GetResZone();
            // Player moving
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                Moving();
            }
            else
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
                _animator.SetBool("Moving", false);

            }
        }

        // Move player via input in joystic direction is draged
        void Moving()
        {
            _animator.SetBool("Moving", true);
            if (Mathf.Abs(_joystick.Horizontal) > 0.5f || Mathf.Abs(_joystick.Vertical) > 0.5f)
            {
                _animator.SetFloat("Speed", 1);
            }
            else
            {
                _animator.SetFloat("Speed", 0);
            }
            rb.velocity = new Vector3(_joystick.Horizontal * speed, GetComponent<Rigidbody>().velocity.y, _joystick.Vertical * speed); // Move player
            _animator.gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical)); // Rotate player
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Resource"))
            {
                if (other.gameObject.GetComponent<ResLoot>().AviableResValue > 0)
                {
                    if (other.gameObject.GetComponent<ResLoot>().resType == ResourceType.Wood)
                    {
                        //ActivateAxe();
                        _animEventHandler.SetAttackType?.Invoke(ResourceType.Wood);
                    }
                    if (other.gameObject.GetComponent<ResLoot>().resType == ResourceType.Stone)
                    {
                        //ActivateCrutch();
                        _animEventHandler.SetAttackType?.Invoke(ResourceType.Stone);
                    }
                    _animator.SetBool("Attack", true);
                }else
                {
                    _animator.SetBool("Attack", false);
                }
            } 
            if(other.gameObject.CompareTag("Finish"))
            {
                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Resource"))
            {
                _animator.SetBool("Attack", false); 
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("HexSide") && (_joystick.Horizontal != 0 || _joystick.Vertical != 0))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + other.GetComponent<BoxCollider>().size.y, transform.position.z);
            }
            if (other.gameObject.CompareTag("OpenZone"))
            {
                int zoneNum = int.Parse (other.name); 
                HexZoneOpenValue openZone = new HexZoneOpenValue();
                ResourceType resourceType = ResourceType.Wood;

                Debug.Log("Zone number = " + zoneNum);
                switch (zoneNum)
                {
                    case 1:
                        openZone = curentZone.hexZoneOpen1;
                        resourceType = curentZone.hexZoneOpen1.hexZoneRsourseType;
                        break;
                    case 2:
                        openZone = curentZone.hexZoneOpen2;
                        resourceType = curentZone.hexZoneOpen2.hexZoneRsourseType;
                        break;
                    case 3:
                        openZone = curentZone.hexZoneOpen3;
                        resourceType = curentZone.hexZoneOpen3.hexZoneRsourseType;
                        break;
                    case 4:
                        openZone = curentZone.hexZoneOpen4;
                        resourceType = curentZone.hexZoneOpen4.hexZoneRsourseType;
                        break;                            
                    case 5:
                        openZone = curentZone.hexZoneOpen5;
                        resourceType = curentZone.hexZoneOpen5.hexZoneRsourseType;
                        break;
                    case 6:
                        openZone = curentZone.hexZoneOpen6;
                        resourceType = curentZone.hexZoneOpen6.hexZoneRsourseType;
                        break;
                }
                switch (resourceType)
                {
                    case ResourceType.Wood:
                        if (resourseManager.resourseWood != 0)
                        {
                            LoseRes(ResourceType.Wood, 1);
                            openZone.GetResurse(1);
                        } 
                        break;
                    case ResourceType.Stone:
                        if (resourseManager.resourseStone != 0)
                        {
                            LoseRes(ResourceType.Stone, 1);
                            openZone.GetResurse(1);
                        }
                        break;
                }
                
            }
            if (other.gameObject.CompareTag("Resource"))
            {
                if (other.gameObject.GetComponent<ResLoot>().AviableResValue == 0)
                { _animator.SetBool("Attack", false); }
            }
        }
        HexSettings GetResZone()
        { 
            RaycastHit[] hit =  Physics.RaycastAll(transform.position, Vector3.down, 1);
            HexSettings hexSettings = new HexSettings();
            foreach (var item in hit)
            { 
                if (item.collider.CompareTag("Hex"))
                {
                    hexSettings = item.collider.gameObject.GetComponentInParent<HexSettings>();
                }
            } 
            return hexSettings;
        }
        void LoseRes(ResourceType rt, int value)
        {
            _resourseManager.LoseResource(rt, value);
        } 
    }
}
