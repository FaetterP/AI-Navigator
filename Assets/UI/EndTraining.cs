using UnityEngine;

namespace Assets.UI
{
    class EndTraining : MonoBehaviour
    {
        [SerializeField] private Canvas _disabledCanvas;
        [SerializeField] private Canvas _enabledCanvas;

        private void OnMouseDown()
        {
            _enabledCanvas.gameObject.SetActive(true);
            _disabledCanvas.gameObject.SetActive(false);
        }
    }
}
