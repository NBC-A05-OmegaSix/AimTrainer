using UnityEngine;
using TMPro;

public class AmmosUI : MonoBehaviour
{
    public TextMeshProUGUI currentAmmoText;
    public TextMeshProUGUI totalAmmoText;
    public TextMeshProUGUI shootingState;
    public GameObject m16ImagePrefab; 
    public GameObject ak47ImagePrefab;
    public GameObject trgImagePrefab;
    private Gun gun; 

    void Start()
    {
        gun = FindObjectOfType<Gun>(); 
        totalAmmoText.text = gun.maxAmmo.ToString(); // 총알 최대 수를 나타내는 값 설정 (총의 종류에 따라 수정될 예정)
    }

    void Update()
    {
        ShowGunImage();

        currentAmmoText.text = gun.currentAmmo.ToString();

        if (gun.currentFireMode == Gun.FireMode.Single)
        {
            shootingState.text = "Single"; 
        }
        else if (gun.currentFireMode == Gun.FireMode.Burst3)
        {
            shootingState.text = "Burst"; 
        }
        else if (gun.currentFireMode == Gun.FireMode.FullAuto)
        {
            shootingState.text = "Full Auto"; 
        }
    }

    private void ShowGunImage()
    {
        //    if (gun.gunType == Gun.GunType.AK47) // gunType에 따라 이미지 변경
        //    {
        //        // AK47 이미지 표시 코드
        //    }
        //    else if (gun.gunType == Gun.GunType.M16)
        //    {
        //        // M16 이미지 표시 코드
        //    }
        //    else if (gun.gunType == Gun.GunType.TRG)
        //    {
        //        // TRG 이미지 표시 코드
        //    }
    }

}
