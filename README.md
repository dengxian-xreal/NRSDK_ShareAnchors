

# Spatial Anchor Sharing Project with NRSDK

This project demonstrates the implementation of spatial anchors using NRSDK 2.2 for shared augmented reality experiences. 

Follow the [NRSDK Spatial Anchor Sharing Tutorial](https://xreal.gitbook.io/nrsdk/development/spatial-anchor/tutorial-sharing-anchors) to understand how the project is structured and how to use the provided scripts.

However, the tutorial is quite cumbersome. This project has all the Photon and Aliyun OSS SDKs installed, and all scripts have been modified, so you can directly clone and use them.


## Supported Devices

This project is configured to support the following devices:
- XREAL Air 2 Ultra
- XREAL Air Light

## Have a try

Before clone this project, you may want to have a try about this project, you can go to release to download the built apk.
In order to facilitate the understanding of the whole process and see the effect, I also took a video, but it is not convenient to operate with one hand, and there are places where buttons were accidentally touched, so you should mainly follow the following steps. In addition, in order to facilitate the demonstration, the video shows sharing an anchor between a mobile phone and a Unity project. You can also operate like this during debugging. Generally, if it is successful in this way, and it can also be successful on two mobile phones.
https://youtu.be/a7L2hzYBaK8

Below is how you should use this APK. 

1. click button *OpenAnchorPanel*

   ![image](https://github.com/dengxian-xreal/NRSDK_ShareAnchors/assets/134575521/bd430422-a503-45a7-b7fb-9a212c0b066e)

3. Click an anchor
 
  ![image](https://github.com/dengxian-xreal/NRSDK_ShareAnchors/assets/134575521/a13aa5e8-bc2e-4b10-b494-d7c1caf63cd2)

3. Place it in any position (not in places with few features, such as a clean wall).

  ![image](https://github.com/dengxian-xreal/NRSDK_ShareAnchors/assets/134575521/98207d5f-a9cd-4b76-9b96-d780a2457fbc)

4. According to the instructions, observe the anchor (mapping in progress) until all guidance bars turn green (mapping successful), then click ✅ (save anchor).

   ![image](https://github.com/dengxian-xreal/NRSDK_ShareAnchors/assets/134575521/cb75ec15-12ac-48ae-99b0-534d8f149577)
   
5. Both the receiver and sender click JoinRoom, after successful entry, the button will turn green, which takes about 3 seconds.

   ![image](https://github.com/dengxian-xreal/NRSDK_ShareAnchors/assets/134575521/af395796-7c5e-4e69-8af7-0509950d3bd7)
6. Click the share button below anchor.

   ![image](https://github.com/dengxian-xreal/NRSDK_ShareAnchors/assets/134575521/95bec1cf-135b-4979-819d-17c7a6fb3924)
   
7. In addition to joining the room, the recipient does not need any other operations. Just walk near the observer's position, and the anchor will be automatically loaded.
