using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.IO;
using SFB;

public class AddCategory : MonoBehaviour
{
    public Image placeholderImage;
    public Button uploadButton;
    // Start is called before the first frame update
    void Start()
    {
        uploadButton.onClick.AddListener(UploadImage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UploadImage()
    {
        StartCoroutine(OpenFileExplorer());
    }

    private IEnumerator OpenFileExplorer()
    {
        string path = StandaloneFileBrowser.OpenFilePanel("Select Image", "", "png,jpg,jpeg", false)[0];
        if (!string.IsNullOrEmpty(path))
        {
            byte[] imageBytes = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageBytes);
            placeholderImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
        yield return null;
    }
}
