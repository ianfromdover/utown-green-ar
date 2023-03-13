using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CaptureScenePhoto : MonoBehaviour
{

    public Button screenshotButton;
    [SerializeField] private float savedMsgDisplayTime = 3.0f;
    [SerializeField] private GameObject ssAlertUI;

    // Start is called before the first frame update
    void Start()
    {
        screenshotButton.onClick.AddListener(OnClickScreenshotButton);
    }

    private void OnClickScreenshotButton()
    {
        StartCoroutine(TakeScreenshot());
    }

    private IEnumerator TakeScreenshot()
    {

        // Wait for the end of the current frame before capturing the screenshot
        yield return new WaitForEndOfFrame();

        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // Get the file path of the saved screenshot and log it to the console
        string filePath = Path.Combine(GetAndroidExternalStoragePath(), "be_longing" + timeStamp + ".png");

        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        Destroy(ss);

        // Wait for one second to allow time for the screenshot to be saved
        yield return new WaitForSeconds(1);

        // Tell user that the screenshot has been saved
        // TODO: to replace with animator that changes opacity
        Debug.Log("Screenshot saved to: " + filePath);
        ssAlertUI.SetActive(true);
        yield return new WaitForSeconds(savedMsgDisplayTime);
        ssAlertUI.SetActive(false);
    }

    private string GetAndroidExternalStoragePath()
    {
        if (Application.platform != RuntimePlatform.Android)
            return Application.persistentDataPath;

        var jc = new AndroidJavaClass("android.os.Environment");
        var path = jc.CallStatic<AndroidJavaObject>("getExternalStoragePublicDirectory",
            jc.GetStatic<string>("DIRECTORY_DCIM"))
            .Call<string>("getAbsolutePath");
        return path;
    }
}