using Aliyun.OSS;
using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class AliyunOSSManager
{
    
    private static AliyunOSSManager _instance;
    public static AliyunOSSManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AliyunOSSManager();
            }
            return _instance;
        }
    }
    private string accessKeyId = "LTAI5tHnacePsyiVjthU6kDs";
    private string accessKeySecret = "KejWRpzZrxYhE8RXC4zWMNCRbeU9Ts";
    private string endpoint = "oss-cn-beijing.aliyuncs.com";//类似：oss-cn-beijing.aliyuncs.com
    private string bucketName = "share-anchor-bucket";

    private OssClient client;

    public AliyunOSSManager()
    {
        client = new OssClient(endpoint, accessKeyId, accessKeySecret);
    }

    public Task UploadFile(string objectName, string localFilename)
    {
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

        try
        {
            client.PutObject(bucketName, objectName, localFilename);
            Debug.Log("File uploaded successfully.");
            tcs.SetResult(true); // Set the task as successfully completed.
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to upload file: " + e.Message);
            tcs.SetResult(false); // Set the task to complete, but failed to return.
        }

        return tcs.Task;
    }

    public Task DownloadFile(string objectName, string localFilename)
    {
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

        try
        {
            OssObject ossObject = client.GetObject(bucketName, objectName);
            using (var requestStream = ossObject.Content)
            {
                byte[] buf = new byte[1024];
                var fs = File.Open(localFilename, FileMode.OpenOrCreate);
                var len = 0;
                while ((len = requestStream.Read(buf, 0, 1024)) != 0)
                {
                    fs.Write(buf, 0, len);
                }
                fs.Close();
            }

            Debug.Log("File downloaded successfully.");
            tcs.SetResult(true); // Set the task to be completed successfully.
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to download file: " + e.Message);
            tcs.SetResult(false); // Set the task to complete, but the return failed.
        }

        return tcs.Task;
    }
}
