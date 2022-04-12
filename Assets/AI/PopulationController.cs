using Assets.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.AI
{
    class PopulationController : MonoBehaviour
    {
        [SerializeField] private TrainingCar _example;
        private TrainingCar[] _cars = new TrainingCar[100];

        private void Start()
        {
            Spawn();
        }

        private void Update()
        {
            if (IsAllDead())
            {
                Respawn();
            }
        }

        private void Respawn()
        {
            foreach(var t in _cars)
            {
                Destroy(t.gameObject);
            }
            Spawn();
        }

        private void Spawn()
        {
            for (int i = 0; i < 100; i++)
            {
                _cars[i] = Instantiate(_example, transform);
                _cars[i].MLP = _example.MLP.Clone();
                _cars[i].MLP.RandomW(1);
            }

        }

        private bool IsAllDead()
        {
            foreach(var t in _cars)
            {
                if (t.IsDead == false)
                    return false;
            }
            return true;
        }
    }
}
