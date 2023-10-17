using UnityEngine;
using TMPro;

public class AmmosUI : MonoBehaviour
{
    public TextMeshProUGUI currentAmmoText;
    public TextMeshProUGUI totalAmmoText;
    private Gun gun; 

    // Start is called before the first frame update
    void Start()
    {
        gun = FindObjectOfType<Gun>(); 
        totalAmmoText.text = gun.maxAmmo.ToString(); // 총알 최대 수를 나타내는 값 설정 (총의 종류에 따라 수정될 예정)
    }

    // Update is called once per frame
    void Update()
    {
        currentAmmoText.text = gun.currentAmmo.ToString(); // 현재 총알 수
    }
}
