using UnityEditor;
using UnityEngine;
using System.IO;

namespace Yorozu
{
	public class ReplaceAssetMenu
	{
		[MenuItem("Assets/Replace Selection Asset")]
		private static void Replace()
		{
			var objects = Selection.objects;
			foreach (var selectObj in objects)
			{
				var path = AssetDatabase.GetAssetPath(selectObj);

				if (string.IsNullOrEmpty(path))
					continue;

				var fullPath = Application.dataPath.Replace("/Assets", "/" + path);
				var ext = Path.GetExtension(path).Substring(1);
				var fileName = Path.GetFileName(path);
				var sourcePath = EditorUtility.OpenFilePanel("Select Replace Asset\n" + fileName, "", ext);

				if (string.IsNullOrEmpty(sourcePath))
					continue;

				File.Copy(sourcePath, fullPath, true);
			}
		
			AssetDatabase.Refresh();
		}
	}
}