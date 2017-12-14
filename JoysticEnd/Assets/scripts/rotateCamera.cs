using System;
using UnityEngine;
using UnityEngine.EventSystems;


    public class rotateCamera : MonoBehaviour, IDragHandler
    {

        Vector2 delta;
        Quaternion originRotation;
        GameObject player;

        Quaternion targetRot;


        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("MainCamera");
        }

        public void OnDrag(PointerEventData eventData)
        {

            delta = eventData.delta;

            originRotation = player.transform.rotation;
            
        }

    private void Update()
    {
        
    }

    private void FixedUpdate()
        {

            targetRot = originRotation * Quaternion.Euler(-delta.y*Time.deltaTime*10, delta.x* Time.deltaTime*11, 0f);
            player.transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, 1);
            player.transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, 0.0f);
        }

    }


