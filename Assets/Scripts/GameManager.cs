using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DinoSpace
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] public GameObject _objectif;
        public int countDino;
        public float incomePerSeconde = 0;
        public float incomeTotal;
        public Container container;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            incomeTotal += incomePerSeconde * Time.deltaTime;
            UIManager.Instance.income.text = incomeTotal + " $";
        }

        public void AddDino(Dino dino)
        {
            countDino++;
            incomePerSeconde += dino.data.moneyPerSecond;
            container.AddDinoToContainer();
        }

        public void GotoDestination(GameObject dino)
        {
            dino.GetComponent<NavMeshAgent>().SetDestination(_objectif.transform.position);
        }

        public float GetIncomeTotal()
        {
            return incomeTotal;
        }

        public void SetIncomeTotal(float newIncomeTotal)
        {
            incomeTotal = newIncomeTotal;
        }
    }
}
