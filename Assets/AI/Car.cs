using Assets.Navigator;
using Assets.Utilities;
using UnityEngine;

namespace Assets.AI
{
    class Car : MonoBehaviour
    {
        public static MLP ForwardMLP = new MLP(Settings.Lengths);
        public static MLP LeftMLP = new MLP(Settings.Lengths);
        public static MLP RightMLP = new MLP(Settings.Lengths);

        private MLP[] _mlps = new MLP[] { LeftMLP, ForwardMLP, RightMLP };
        private NavigatorElement _currentElement;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _currentElement = collision.GetComponent<NavigatorElement>();
        }

        private void Update()
        {
            Vector2 position = transform.localPosition - _currentElement.transform.localPosition;
            double z = _mlps[_currentElement.Index - 1].Predict(new double[] { position.x, position.y, transform.localEulerAngles.z})[0];
            transform.localEulerAngles += new Vector3(0, 0, (float)z);
            transform.localPosition += transform.up * Settings.CarSpeed;
        }
    }
}
