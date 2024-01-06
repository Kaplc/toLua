using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;
using ZFramework;

public class ToLuaCustomLoader : LuaFileUtils
{
    public override byte[] ReadFile(string filePath)
    {
        byte[] buffer = null;

        // 添加Lua后缀, 真实后缀是".text"
        if (!filePath.EndsWith(".lua"))
        {
            filePath += ".lua";
        }
        // 切割文件路径
        string[] filePathStr = filePath.Split('/');
        // 先从AB包加载脚本
        TextAsset luaCode = ABManager.Instance.Load<TextAsset>("lua", filePathStr[filePathStr.Length - 1]);
        // 从Resources加载
        if (luaCode != null)
        {
            string path = "Lua/" + filePath;
            luaCode = Resources.Load<TextAsset>(path);
        }

        buffer = new byte[luaCode.bytes.Length];
        buffer = luaCode.bytes;
        Resources.UnloadAsset(luaCode);

        return buffer;
    }
}
