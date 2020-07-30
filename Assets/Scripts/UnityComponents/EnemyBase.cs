using Assets.UnityComponents;
using Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UnityComponents
{
    public abstract class EnemyBase : GameEntity
    {
        public GameObject[] fireDamageParticles;
        public GameObject[] physicDamageParticles;
        public GameObject[] lightningDamageParticles;
        public GameObject[] waterDamageParticles;

        protected override void Start()
        {
            base.Start();
            HideParticles();
        }

        public virtual void DisplayDamage(RecievedDamage rD)
        {
            float[] mults = NormalizeDmg(rD);
            ShowParticles(mults);
            StartCoroutine(CallDelayedAction(HideParticles, 1f));
        }

        protected virtual float[] NormalizeDmg(RecievedDamage rD)
        {
            float[] ar = { rD.fire, rD.lightning, rD.physic, rD.water};
            if(ar.Max() != 0)
            {
                for (int i = 0; i < ar.Length; i++)
                {
                    ar[i] = ar[i] / ar.Max();
                }

                return ar;
            }

            return ar;
        }

        protected virtual void ShowParticles(float[] mults)
        {
            foreach (var i in fireDamageParticles)
            {
                //i.transform.localScale = new Vector3(mults[0], mults[0]);
                i.SetActive(true);
            }
            foreach (var i in lightningDamageParticles)
            {
                //i.transform.localScale = new Vector3(mults[1], mults[1]);
                i.SetActive(true);
            }
            foreach (var i in physicDamageParticles)
            {
                //i.transform.localScale = new Vector3(mults[2], mults[2]);
                i.SetActive(true);
            }
            foreach (var i in waterDamageParticles)
            {
                //i.transform.localScale = new Vector3(mults[3], mults[3]);
                i.SetActive(true);
            }
        }

        protected virtual void HideParticles()
        {
            foreach(var i in fireDamageParticles)
            {
                i.SetActive(false);
            }
            foreach (var i in physicDamageParticles)
            {
                i.SetActive(false);
            }
            foreach (var i in lightningDamageParticles)
            {
                i.SetActive(false);
            }
            foreach (var i in waterDamageParticles)
            {
                i.SetActive(false);
            }
        }
    }
}
