using Assets.Utilities;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Navigator
{
    [RequireComponent(typeof(Image))]
    class NavigatorElement : MonoBehaviour
    {
        [SerializeField] private Sprite _forward;
        [SerializeField] private Sprite _right;
        [SerializeField] private Sprite _left;

        private CycleArray<Sprite> _array;
        private Image _thisImage;
        private bool _isSelected;

        private void Awake()
        {
            _thisImage = GetComponent<Image>();
            _array = new CycleArray<Sprite>(new Sprite[] { _forward, _right, _left });
            _isSelected = false;
        }

        private void Start()
        {
            _thisImage.sprite = _array.GetNext();
        }

        private void OnMouseDown()
        {
            _thisImage.sprite = _array.GetNext();
        }

        private void OnMouseEnter()
        {
            _isSelected = true;
        }

        private void OnMouseExit()
        {
            _isSelected = false;
        }

        private void Update()
        {
            if (_isSelected)
            {
                float mw = Input.GetAxis("Mouse ScrollWheel");
                transform.localEulerAngles += new Vector3(0, 0, 90 * Math.Sign(mw));
            }
        }
    }
}
