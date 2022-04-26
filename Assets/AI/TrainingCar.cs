using Assets.Utilities;
using System;
using UnityEngine;

namespace Assets.AI
{
    class TrainingCar : MonoBehaviour
    {
        public int _mlpIndex;
        public static MLP[] MLPs = new MLP[] { Car.LeftMLP, Car.ForwardMLP, Car.RightMLP };

        public bool IsDead = false;
        public MLP MLP;

        private void Awake()
        {
            //MLP = MLPs[_mlpIndex].Clone();
        }

        private void Update()
        {
            if (IsDead)
                return;
            Vector2 position = transform.localPosition;
            double z = MLP.Predict(new double[] { position.x, position.y, transform.localEulerAngles.z })[0] * 5 - 2.5;
            transform.localEulerAngles += new Vector3(0, 0, (float)z);
            transform.localPosition += transform.up * Settings.CarSpeed;

            if (Math.Abs(transform.localPosition.x) > 50 || Math.Abs(transform.localPosition.y) > 50)
                IsDead = true;
        }

        public double GetScore()
        {
            if (_mlpIndex == 0)
            {
                double ret = 0;

                ret += 1 / Math.Pow(Math.Abs(transform.localPosition.x + 50), 1 / 10d);
                ret += 1 / Math.Pow(Math.Abs(transform.localPosition.y - 0), 1);
                ret += 1 / Math.Pow(Math.Abs(transform.localEulerAngles.z - 90), 2);

                return ret;
            }
            else if (_mlpIndex == 1)
            {
                double ret = 0;

                ret += 1 / Math.Pow(Math.Abs(transform.localPosition.x - 0), 1);
                ret += 1 / Math.Pow(Math.Abs(transform.localPosition.y - 50), 1 / 10d);
                ret += 1 / Math.Pow(Math.Abs(transform.localEulerAngles.z - 0), 2);

                return ret;
            }
            else
            {
                double ret = 0;

                ret += 1 / Math.Pow(Math.Abs(transform.localPosition.x - 50), 1 / 10d);
                ret += 1 / Math.Pow(Math.Abs(transform.localPosition.y - 0), 1);
                ret += 1 / Math.Pow(Math.Abs(transform.localEulerAngles.z - 270), 2);
                return ret;
            }
        }

    }
}
