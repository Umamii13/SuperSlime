using UnityEngine;

public class FadeingUI : MonoBehaviour
{
    [SerializeField] public CanvasGroup _canvasGroup;
    //public Tween fadetween;
    public PlayerRespawn respawn;
   
    public bool isfade = true;
    private void Awake ()
    {
        //_canvasGroup.DOFade(0, 2);
        respawn= GetComponent<PlayerRespawn>();
    }
    
    public void Fader()
    {
        isfade = !isfade;

        if(isfade)
        {
            //_canvasGroup.DOFade(0, 0.5f);//fadeout false
            
        }
        else
        {
            //_canvasGroup.DOFade(1, 2);//fadein true
            
            /*if(_canvasGroup.alpha == 1)
                respawn.canrespawn = true;*/
        }
    }
        
}
