using UnityEngine;

namespace FlimcyColorPC
{
    public class ColorButtons : MonoBehaviour
    {
        public ColorType ColorButtonType;

        public string Tag = "FC";

        public ColorManagerMain ColorManagerScript;

        [Range(0, 9)]
        public int Value = 0;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tag))
                return;

            // Convert 0-9 into 0.0-1.0
            float colorValue = Value / 9f;

            switch (ColorButtonType)
            {
                case ColorType.Red:
                    ColorManagerScript.currentColor.r = colorValue;
                    break;

                case ColorType.Green:
                    ColorManagerScript.currentColor.g = colorValue;
                    break;

                case ColorType.Blue:
                    ColorManagerScript.currentColor.b = colorValue;
                    break;
            }

            ColorManagerScript.UpdateColor();
        }

        public enum ColorType
        {
            Red,
            Green,
            Blue
        }
    }
}