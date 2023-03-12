using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureScenePhoto : MonoBehaviour
{

    public string imageFileName;

    public Button screenshotButton;

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

        // Capture a screenshot and save it as "test_ss"
        ScreenCapture.CaptureScreenshot(imageFileName + ".png");

        // Wait for one second to allow time for the screenshot to be saved
        yield return new WaitForSeconds(1);

        // Get the file path of the saved screenshot and log it to the console
        string filePath = Application.dataPath + "/" + imageFileName+ ".png";
        
        Debug.Log("Screenshot saved to: " + filePath);
    }
}
