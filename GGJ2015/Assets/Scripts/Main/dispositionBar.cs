using UnityEngine;
using System.Collections;

public class dispositionBar : MonoBehaviour {

    GameController gameController;
    public RectTransform inside;

    float widthProportion, height;
	void Start () {

        var findGC = GameObject.Find("GameController");
        if (findGC == null)
            print("GameController not found");
        else
            gameController = findGC.GetComponent<GameController>();

        widthProportion = inside.rect.width / 100f;
        height = inside.rect.height;
    }
	
	void Update () 
    {
        if(gameController!= null)
            SetSize(inside, new Vector2(gameController.getDisposicao() * widthProportion, height));
    }

    // Source code from http://orbcreation.com/orbcreation/page.orb?1099 - tks!
    public void SetSize(this RectTransform trans, Vector2 newSize)
    {
        Vector2 oldSize = trans.rect.size;
        Vector2 deltaSize = newSize - oldSize;
        trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
    }
    public void SetWidth(this RectTransform trans, float newSize)
    {
        SetSize(trans, new Vector2(newSize, trans.rect.size.y));
    }
}
