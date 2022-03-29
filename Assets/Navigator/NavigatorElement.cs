using Assets.Utilities;
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

        private void Awake()
        {
            _thisImage = GetComponent<Image>();
            _array = new CycleArray<Sprite>(new Sprite[] { _forward, _right, _left });
        }

        private void Start()
        {
            _thisImage.sprite = _array.GetNext();
        }

        private void OnMouseDown()
        {
            _thisImage.sprite = _array.GetNext();
        }
    }
}
