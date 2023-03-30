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
            Vector3 idealPostion = target.position + target.rotation * offset + target.transform.forward * (-distance);
            Vector3 positionSmooth = Vector3.Lerp(transform.position, idealPostion, 2);
            transform.position = positionSmooth;

            Quaternion rotationSmooth = Quaternion.Lerp(transform.rotation, target.transform.rotation, 0.2f);
            transform.rotation = rotationSmooth;

            this.transform.LookAt(target.transform.position + offset);

        }
    }
}
