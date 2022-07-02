using Assets.Utilities;
using UnityEngine;
using UnityEngine.UI;

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
                int maxIndex = 0;
                double maxValue = _cars[0].GetScore();

                for(int i = 1; i < _cars.Length; i++)
                {
                    double value = _cars[1].GetScore();
                    if (maxValue < value)
                    {
                        maxValue = value;
                        maxIndex = i;
                    }
                }

                Spawn(maxIndex);
            }
        }

        private void Spawn()
        {
            for (int i = 0; i < _cars.Length; i++)
            {
                _cars[i] = Instantiate(_example, transform);
                _cars[i].MLP = new MLP(Settings.Lengths);
                _cars[i].MLP.RandomW(0.1);
            }

        }

        MLP bestMLP;

        private void OnDisable()
        {
            Debug.Log(bestMLP._wMatrices[0][0, 0]);
        }

        private void Spawn(int index)
        {
            bestMLP = _cars[index].MLP.Clone();
            Car.MLPs[_cars[index]._mlpIndex] = bestMLP;

            foreach (var t in _cars)
            {
                Destroy(t.gameObject);
            }

            for (int i = 1; i < _cars.Length; i++)
            {
                _cars[i] = Instantiate(_example, transform);
                _cars[i].MLP = bestMLP.Clone();
                _cars[i].MLP.RandomW(0.1);
            }

            _cars[0] = Instantiate(_example, transform);
            _cars[0].MLP = bestMLP.Clone();
            _cars[0].GetComponent<Image>().color = Color.red;
            _cars[0].transform.SetAsLastSibling();
        }

        private bool IsAllDead()
        {
            foreach (var t in _cars)
            {
                if (t.IsDead == false)
                    return false;
            }
            return true;
        }
    }
}
