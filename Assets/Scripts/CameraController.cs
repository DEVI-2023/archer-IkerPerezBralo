using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class CameraController : MonoBehaviour
    {

        // El objeto al que va a seguir la c�mara
        [SerializeField]
        private Transform target;

        // �ngulo de la c�mara
        [SerializeField]
        private float angle;

        // Distancia a la que se coloca la c�mara con respecto a la arquera
        [SerializeField]
        private float distance;

        // Desplazamiento con respecto al pivote de la arquera 
        // (para que la c�mara est� m�s orienta hacia la cabeza que a los pies)
        [SerializeField]
        private Vector3 offset;

        // Velocidad a la que se mueve la c�mara con Vector3.MoveTowards()
        //[SerializeField]
        //private float travelSpeed;

        // Tiempo que tarda la c�mara en moverse a la nueva ubicaci�n con Vector3.Lerp()
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
