using UnityEngine;
using System.Collections;
using System.IO;
public class LoadAsset : MonoBehaviour {

    AssetBundleCreateRequest asset;//定义一个资源包创建请求
    IEnumerator LoadAssetBundle() {

        FileStream AssetIO = new FileStream(Application.dataPath + @"/StreamingAssets/好孩子/001.dat", FileMode.Open, FileAccess.ReadWrite); //创建文件流（对象现含有中文）
        byte[] assetbytes = new byte[AssetIO.Length];
        AssetIO.Read(assetbytes, 0, (int)AssetIO.Length);
        AssetIO.Close();

        asset = AssetBundle.LoadFromMemoryAsync(assetbytes);//从内存中创建资源
        yield return asset;

        AssetBundle LoadAsset = asset.assetBundle;//这样就能得到我们需要的资源包了
        if (asset.isDone) {
            Instantiate(LoadAsset.LoadAsset("Test_001"));
        }
    }
}