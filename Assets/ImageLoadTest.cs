using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoadTest : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        var type = typeof(Texture2D);
        image.transform.DOLocalMove(new Vector3(0, 0, 0), 1).SetEase(Ease.InQuad).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("11231231");
        Debug.Log("srtewtert");
        Debug.Log("345353345454545454");
    }
}
