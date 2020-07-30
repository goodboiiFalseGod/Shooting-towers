using Assets.UnityComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UnityComponents
{
    public abstract class TowerBase : GameEntity
    {
        public GameObject[] shootParticles;

        protected override void Start()
        {
            base.Start();
            HideParticles();
        }

        public virtual void DisplayShoot()
        {
            ShowParticles();
            //HideParticles();
            StartCoroutine(CallDelayedAction(HideParticles, 0.5f));
        }

        protected virtual void ShowParticles()
        {
            for (int i = 0; i < shootParticles.Length; i++)
            {
                shootParticles[i].SetActive(true);
            }
        }

        protected virtual void HideParticles()
        {
            for (int i = 0; i < shootParticles.Length; i++)
            {
                shootParticles[i].SetActive(false);
            }
        }
    }
}
