// -------------------------------------------------------------------
// - A custom asset importer for Unity 3D game engine by Sarper Soher-
// - http://www.sarpersoher.com        
// - http://www.sarpersoher.com/a-custom-asset-importer-for-unity/
// -------------------------------------------------------------------
// - This script utilizes the file names of the imported assets      -
// - to change the import settings automatically as described        -
// - in this script                                                  -
// -------------------------------------------------------------------

using UnityEditor;
using UnityEngine; // Most of the utilities we are going to use are contained in the UnityEditor namespace

// We inherit from the AssetPostProcessor class which contains all the exposed variables and event triggers for asset importing pipeline
internal sealed class CustomAssetImporter : AssetPostprocessor
{
    #region Pre Processors

    // This event is raised when a texture asset is imported
    private void OnPreprocessTexture()
    {
        // Get the reference to the assetImporter (From the AssetPostProcessor class) and unbox it to a TextureImporter (Which is inherited and extends the AssetImporter with texture specific utilities)
        var importer = assetImporter as TextureImporter;

        // Set the texture import type drop-down to advanced so our changes reflect in the import settings inspector
        importer.textureType = TextureImporterType.Sprite;
        // Below line may cause problems with systems and plugins that utilize the textures (read/write them) like NGUI so comment it out based on your use-case
        importer.isReadable = false;
        importer.filterMode = FilterMode.Point;
        importer.spritePixelsPerUnit = 100;
        TextureImporterSettings ts = new TextureImporterSettings();
        importer.ReadTextureSettings(ts);
        ts.spriteAlignment = 0;
        importer.SetTextureSettings(ts);
        importer.textureCompression = TextureImporterCompression.Uncompressed;
    }

    // This event is raised when a new mesh asset is imported
    private void OnPreprocessModel() { }

    // This event is raised every time an audio asset is imported
    // This method does nothing at the moment, just a skeleton to fill in if we ever need to do audio specific importing
    // Imports audio assets in the default way without changing anything
    private void OnPreprocessAudio() { }
    
    #endregion

    
    #region Post Processors

    // This event is called as soon as the texture asset is imported successfully
    // Does nothing currently, just here for future possibilities
    private void OnPostprocessTexture(Texture2D import) { }

    // This event is called as soon as the mesh asset is imported successfully
    private void OnPostprocessModel(GameObject import) { }

    // This event is called as soon as the audio asset is imported successfully
    private void OnPostprocessAudio(AudioClip import) { }

    #endregion
}