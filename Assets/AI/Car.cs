using Assets.Navigator;
using Assets.Utilities;
using UnityEngine;

namespace Assets.AI
{
    class Car : MonoBehaviour
    {
        public static MLP[] MLPs = new MLP[3];
        private NavigatorElement _currentElement;

        private void Start()
        {
            Debug.Log(MLPs[0]._wMatrices[0][0,0]);
            Debug.Log(MLPs[1]._wMatrices[0][0,0]);
            Debug.Log(MLPs[2]._wMatrices[0][0,0]);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            _currentElement = collision.GetComponent<NavigatorElement>();
        }

        private void Update()
        {
            Vector2 position = _currentElement.transform.worldToLocalMatrix.MultiplyPoint(transform.position);
            Vector3 angles = transform.localEulerAngles - _currentElement.transform.localEulerAngles;
            Debug.Log(_currentElement.Index - 1);
            double rotateAngle = MLPs[_currentElement.Index - 1].Predict(new double[] { position.x, position.y, angles.z})[0] * 5 - 2.5;
            transform.localEulerAngles += new Vector3(0, 0, (float)rotateAngle);
            transform.localPosition += transform.up * Settings.CarSpeed;
        }
    }
}
