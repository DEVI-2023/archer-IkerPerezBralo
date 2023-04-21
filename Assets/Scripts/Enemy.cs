using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class Enemy : MonoBehaviour, IScoreProvider
    {

        // Cuántas vidas tiene el enemigo
        [SerializeField]
        private int hitPoints;

        private Animator animator;

        public event IScoreProvider.ScoreAddedHandler OnScoreAdded;

        private bool lightState;

        void Start()
        {
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
            this.GetComponent<Transform>().Translate(new Vector3(UnityEngine.Random.Range(-20.0f, 20.0f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(-5.0f, 10.0f)), Space.Self);
        }

        // Método que se llamará cuando el enemigo reciba un impacto
        public void Hit()
        {
            this.animator.SetTrigger("Hit");
            hitPoints--;
        }

        private void Die()
        {
                this.animator.SetTrigger("Die");
        }

        private void OnTriggerEnter(Collider other)
        {
            Hit();
            if (hitPoints == 0)
            {
                Die();
                Destroy(this.gameObject, 2f);
                //  lightState = true;
                //GameObject.FindGameObjectWithTag("Light").SetActive(lightState);
                //  Vector3 transform = new Vector3(-235f, -206f, 176f);



            }
        }

    }
    

}