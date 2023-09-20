using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class PlayerHUD : MonoBehaviour
    {
        
        [Header("HP")]
        [SerializeField] private Slider hpSlider; 
        [SerializeField] private GameObject liveImage; 
        [SerializeField] private GameObject liveImageGroup; 
        [Space(3)]
        [Header("Score")]
        [SerializeField] private TMP_Text scoreText;
        
        private List<GameObject> _liveImages;

        private void Awake()
        {
            _liveImages = new List<GameObject>();
        }

        public void UpdateHealthHUD(int hp, int hpMax, int livesCount)
        {
            hpSlider.maxValue = hpMax;
            hpSlider.value = hp;
            while (_liveImages.Count != livesCount)
            {
                if (_liveImages.Count < livesCount)
                {
                    _liveImages.Add(Instantiate(liveImage, 
                        liveImageGroup.transform));
                }
                else if (_liveImages.Count > livesCount)
                {
                    GameObject live = _liveImages.Last();
                    _liveImages.Remove(live);
                    Destroy(live);
                }
            }
        }

        public void UpdateScoreHUD(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}
