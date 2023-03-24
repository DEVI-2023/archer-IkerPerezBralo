using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class CameraController : MonoBehaviour
    {

        // El objeto al que va a seguir la cámara
        [SerializeField]
        private Transform target;

        // Ángulo de la cámara
        [SerializeField]
        private float angle;

        // Distancia a la que se coloca la cámara con respecto a la arquera
        [SerializeField]
        private float distance;

        // Desplazamiento con respecto al pivote de la arquera 
        // (para que la cámara esté más orienta hacia la cabeza que a los pies)
        [SerializeField]
        private Vector3 offset;

        // Velocidad a la que se mueve la cámara con Vector3.MoveTowards()
        //[SerializeField]
        //private float travelSpeed;

        // Tiempo que tarda la cámara en moverse a la nueva ubicación con Vector3.Lerp()
        [SerializeField]
        private float travelTime;

        [SerializeField]
        private Vector3 rotationOffset;

        void FixedUpdate()
        {
            checkCameraBehaviour();
        }

        void checkCameraBehaviour()
        {
            Vector3 idealPostion = target.position + target.rotation * offset;
            idealPostion.z = idealPostion.z - distance;
            idealPostion.y = idealPostion.y + distance/2;
            Vector3 positionSmooth = Vector3.Lerp(transform.position, idealPostion, 2);
            transform.position = positionSmooth;

            Quaternion idealRotation = target.rotation * Quaternion.Euler(target.transform.rotation.eulerAngles);
            Quaternion rotationSmooth = Quaternion.Lerp(transform.rotation, idealRotation, 5);
            transform.rotation = rotationSmooth;

            this.transform.LookAt(target);

        }
    }
}
