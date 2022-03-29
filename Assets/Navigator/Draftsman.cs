using UnityEngine;

namespace Assets.Navigator
{
    class Draftsman : MonoBehaviour
    {
        [SerializeField] private int _x, _y;
        [SerializeField] private GameObject _element;

        private void Start()
        {
            Draw();
        }

        private void Draw()
        {
            for (int i = 0; i < _x; i++)
            {
                for (int j = 0; j < _y; j++)
                {
                    GameObject element = Instantiate(_element, transform);
                    element.transform.localPosition = new Vector2(100 * (i - _x / 2f), 100 * (j - _y / 2f));
                }
            }
        }
    }
}
