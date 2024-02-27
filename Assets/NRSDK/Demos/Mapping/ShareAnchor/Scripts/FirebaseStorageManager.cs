// using Firebase;
// using Firebase.Extensions;
// using Firebase.Storage;
// using System;
// using System.IO;
// using System.Threading;
// using System.Threading.Tasks;
// using UnityEngine;

// public class FirebaseStorageManager : MonoBehaviour
// {
//     public static FirebaseStorageManager Instance { get; private set; }
//     public string storageBasePath = "gs://nrsdk-63305.appspot.com/";

//     private FirebaseStorage storage;
//     private CancellationTokenSource cancellationTokenSource;
//     private bool operationInProgress = false;
    
//     public const string MapFolder = "XrealMaps";

//     void Start()
//     {
//         FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
//         {
//             FirebaseApp.Create();
//             storage = FirebaseStorage.DefaultInstance;
//             cancellationTokenSource = new CancellationTokenSource();
//         });

// 		if (Instance == null)
//     	{
//         	Instance = this;
//         	DontDestroyOnLoad(gameObject); // Optional, if you want this instance to be preserved during scene transitions.
//     	}
//     	else
//     	{
//        		Destroy(gameObject); // If an instance already exists, destroy the additional instances.
//     	}
        
//     }

//     public Task UploadFile(string fileName, string localFilePath)
// {
//     string localFile = localFilePath;
//     string storagePath = Path.Combine(storageBasePath, fileName);

//     // Check whether the file exists.
//     if (!File.Exists(localFile))
//     {
//         Debug.LogError($"File {localFile} does not exist!");
//         return Task.CompletedTask; // If the file does not exist, return a completed task.
//     }
//     else
//     {
//         Debug.Log($"File {localFile} 11111 exist!");
//     }

//     StorageReference storageRef = storage.GetReferenceFromUrl(storagePath);

//     Debug.Log($"Uploading {localFile} to {storagePath}...");

//     // Create a stream with FileStream
//     Stream fileStream = new FileStream(localFile, FileMode.Open);

//     // Create a TaskCompletionSource to identify when the task is completed.
//     TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

//     // Use PutStreamAsync to upload the stream.
//     storageRef.PutStreamAsync(fileStream).ContinueWithOnMainThread(task =>
//     {
//         if (task.IsFaulted || task.IsCanceled)
//         {
//             Debug.LogError(task.Exception.ToString());
//             tcs.SetResult(false); // Set the task to complete, but failed to return.
//         }
//         else
//         {
//             Debug.Log("File uploaded successfully.");
//             tcs.SetResult(true); // Set the task as successfully completed.
//         }
//     });

//     // Return the task, allowing the caller to wait for it to complete.
//     return tcs.Task;
// }



//     public Task DownloadFile(string fileName, string localFilePath)
// {
//     string localFile = localFilePath;
//     string storagePath = Path.Combine(storageBasePath, fileName);
//     StorageReference storageRef = storage.GetReferenceFromUrl(storagePath);

//     Debug.Log($"Downloading {storagePath} to {localFile}...");

//     // Create a TaskCompletionSource to indicate when the task is completed.
//     TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

//     storageRef.GetFileAsync(localFile, new StorageProgress<DownloadState>(state =>
//     {
//         Debug.Log($"Downloading {state.BytesTransferred} of {state.TotalByteCount} bytes.");
//     }), cancellationTokenSource.Token).ContinueWithOnMainThread(task =>
//     {
//         if (task.IsFaulted || task.IsCanceled)
//         {
//             Debug.LogError(task.Exception.ToString());
//             tcs.SetResult(false); // Set the task to complete, but the return failed.
//         }
//         else
//         {
//             Debug.Log("File downloaded successfully.");
//             tcs.SetResult(true); // Set the task to be completed successfully.
//         }
//     });

    
//     return tcs.Task;
// }

//     public void CancelOperation()
//     {
//         if (operationInProgress && cancellationTokenSource != null)
//         {
//             Debug.Log("Cancelling operation...");
//             cancellationTokenSource.Cancel();
//             cancellationTokenSource = new CancellationTokenSource();
//         }
//     }
// }