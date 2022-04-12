using Assets.Utilities;
using System;
using UnityEngine;

namespace Assets.AI
{
    class TrainingCar : MonoBehaviour
    {
        private static MLP RightMLP = Car.RightMLP;

        public bool IsDead = false;
        public MLP MLP = RightMLP.Clone();

        private void Update()
        {
            if (IsDead)
                return;
            Vector2 position = transform.localPosition;
            double z = MLP.Predict(new double[] { position.x, position.y, transform.localEulerAngles.z })[0]*5-2.5;
            transform.localEulerAngles += new Vector3(0, 0, (float)z);
            transform.localPosition += transform.up * Settings.CarSpeed;

            if (Math.Abs(transform.localPosition.x) > 50 || Math.Abs(transform.localPosition.y) > 50)
                IsDead = true;
        }

        private double GetScore()
        {
            double ret = 0;
            ret += Math.Abs(transform.localPosition.y - 0);
            ret += Math.Abs(transform.localPosition.x - 50);
            return ret;
        }

    }
}
