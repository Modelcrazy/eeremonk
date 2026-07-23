using Photon.VR;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FlimcyColorPC
{
    public class ColorManagerMain : MonoBehaviour
    {
        public float redMultiplier = 1f;
        public float greenMultiplier = 1f;
        public float blueMultiplier = 1f;

        public Color currentColor;

        public TextMeshPro redValueText;
        public TextMeshPro greenValueText;
        public TextMeshPro blueValueText;

        public List<SkinnedMeshRenderer> OfflinePlayerSkin;

        private void Start()
        {
            LoadColor();
            UpdateColor();
        }

        public void UpdateColor()
        {
            float trueRed = currentColor.r * redMultiplier;
            float trueGreen = currentColor.g * greenMultiplier;
            float trueBlue = currentColor.b * blueMultiplier;

            Color myColour = new Color(
                Mathf.Clamp01(trueRed),
                Mathf.Clamp01(trueGreen),
                Mathf.Clamp01(trueBlue)
            );

            PhotonVRManager.SetColour(myColour);

            foreach (SkinnedMeshRenderer SMR in OfflinePlayerSkin)
            {
                if (SMR != null)
                {
                    // Works with Unlit materials like "Body"
                    SMR.material.SetColor("_Color", myColour);
                    SMR.material.SetColor("_BaseColor", myColour);
                }
            }

            UpdateColorCode();
            SaveColor();
        }

        private void UpdateColorCode()
        {
            int redValue = Mathf.Clamp(Mathf.FloorToInt(currentColor.r * 10), 0, 9);
            int greenValue = Mathf.Clamp(Mathf.FloorToInt(currentColor.g * 10), 0, 9);
            int blueValue = Mathf.Clamp(Mathf.FloorToInt(currentColor.b * 10), 0, 9);

            if (redValueText != null)
                redValueText.text = redValue.ToString();

            if (greenValueText != null)
                greenValueText.text = greenValue.ToString();

            if (blueValueText != null)
                blueValueText.text = blueValue.ToString();
        }

        private void SaveColor()
        {
            PlayerPrefs.SetFloat("RedMultiplier", redMultiplier);
            PlayerPrefs.SetFloat("GreenMultiplier", greenMultiplier);
            PlayerPrefs.SetFloat("BlueMultiplier", blueMultiplier);

            PlayerPrefs.SetFloat("RedValue", currentColor.r);
            PlayerPrefs.SetFloat("GreenValue", currentColor.g);
            PlayerPrefs.SetFloat("BlueValue", currentColor.b);

            for (int i = 0; i < OfflinePlayerSkin.Count; i++)
            {
                if (OfflinePlayerSkin[i] != null)
                {
                    Color smrColor = OfflinePlayerSkin[i].material.color;

                    PlayerPrefs.SetFloat($"SMR{i}_Red", smrColor.r);
                    PlayerPrefs.SetFloat($"SMR{i}_Green", smrColor.g);
                    PlayerPrefs.SetFloat($"SMR{i}_Blue", smrColor.b);
                }
            }

            PlayerPrefs.Save();
        }

        private void LoadColor()
        {
            redMultiplier = PlayerPrefs.GetFloat("RedMultiplier", 1f);
            greenMultiplier = PlayerPrefs.GetFloat("GreenMultiplier", 1f);
            blueMultiplier = PlayerPrefs.GetFloat("BlueMultiplier", 1f);

            if (PlayerPrefs.HasKey("RedValue") &&
                PlayerPrefs.HasKey("GreenValue") &&
                PlayerPrefs.HasKey("BlueValue"))
            {
                currentColor = new Color(
                    PlayerPrefs.GetFloat("RedValue"),
                    PlayerPrefs.GetFloat("GreenValue"),
                    PlayerPrefs.GetFloat("BlueValue")
                );
            }

            for (int i = 0; i < OfflinePlayerSkin.Count; i++)
            {
                if (OfflinePlayerSkin[i] != null &&
                    PlayerPrefs.HasKey($"SMR{i}_Red") &&
                    PlayerPrefs.HasKey($"SMR{i}_Green") &&
                    PlayerPrefs.HasKey($"SMR{i}_Blue"))
                {
                    Color smrColor = new Color(
                        PlayerPrefs.GetFloat($"SMR{i}_Red"),
                        PlayerPrefs.GetFloat($"SMR{i}_Green"),
                        PlayerPrefs.GetFloat($"SMR{i}_Blue")
                    );

                    OfflinePlayerSkin[i].material.SetColor("_Color", smrColor);
                    OfflinePlayerSkin[i].material.SetColor("_BaseColor", smrColor);
                }
            }
        }
    }
}