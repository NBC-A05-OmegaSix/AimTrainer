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
        totalAmmoText.text = gun.maxAmmo.ToString(); // �Ѿ� �ִ� ���� ��Ÿ���� �� ���� (���� ������ ���� ������ ����)
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
        //    if (gun.gunType == Gun.GunType.AK47) // gunType�� ���� �̹��� ����
        //    {
        //        // AK47 �̹��� ǥ�� �ڵ�
        //    }
        //    else if (gun.gunType == Gun.GunType.M16)
        //    {
        //        // M16 �̹��� ǥ�� �ڵ�
        //    }
        //    else if (gun.gunType == Gun.GunType.TRG)
        //    {
        //        // TRG �̹��� ǥ�� �ڵ�
        //    }
    }

}
