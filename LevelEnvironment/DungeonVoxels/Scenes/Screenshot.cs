using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CameraCapture : MonoBehaviour
{
    // Reference the 'Main Camera' by name
    public Camera mainCamera;

    void Start()
    {
        // If you haven't assigned the camera in the Inspector, try finding it automatically 
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Capture image on Spacebar press
        {
            StartCoroutine(CaptureAndSaveImage());
        }
    }

    IEnumerator CaptureAndSaveImage() 
    {
        // Wait till the end of the frame to ensure all rendering is done
        yield return new WaitForEndOfFrame();

        // Create a temporary RenderTexture of the same size as the screen
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
        
        // Store the original active RenderTexture and the original camera's targetTexture
        RenderTexture originalActive = RenderTexture.active;
        RenderTexture originalTargetTexture = mainCamera.targetTexture;

        // Set the targetTexture of the camera to the temporary render texture
        mainCamera.targetTexture = rt;

        // Render the camera's view onto the temporary render texture
        mainCamera.Render();

        // Set the active RenderTexture to the temporary one so we can read from it
        RenderTexture.active = rt;

        // Create a new Texture2D and read the RenderTexture image into it
        Texture2D image = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
        image.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        image.Apply();

        // Restore the original active RenderTexture and the camera's targetTexture
        RenderTexture.active = originalActive;
        mainCamera.targetTexture = originalTargetTexture; 

        // Clean up the temporary RenderTexture
        Destroy(rt);

        // Encode the Texture2D to a PNG
        byte[] imageBytes = image.EncodeToPNG();

        // Save the PNG to a file in the persistent data directory
        string filePath = Path.Combine(Application.persistentDataPath, "SavedImage.png");
        File.WriteAllBytes(filePath, imageBytes);

        // Clean up the Texture2D to release the memory
        Destroy(image);

        Debug.Log("Image saved to: " + filePath);
    }
}
