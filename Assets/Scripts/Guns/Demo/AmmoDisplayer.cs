using TMPro;
using UnityEngine;

namespace Fury.Guns.Demo
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class AmmoDisplayer : MonoBehaviour
    {
        [SerializeField]
        private PlayerGunSelector GunSelector;
        private TextMeshProUGUI AmmoText;

        private void Awake()
        {
            AmmoText = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            AmmoText.SetText(
               $"{GunSelector.ActiveGun.ammoConfig.CurrentClipAmmo} / "
               + $"{GunSelector.ActiveGun.ammoConfig.CurrentAmmo}"
           );
        }
    }
}