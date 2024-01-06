using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;
using ZFramework;

public class ToLuaManager : BaseMonoAutoSingleton<ToLuaManager>
{
    private LuaState luaState;
    public LuaState LuaState
    {
        get
        {
            if (luaState is null)
            {
                InitToLua();
            }
            return luaState;
        }
    }

    /// <summary>
    /// 初始化toLua解释器
    /// </summary>
    private void InitToLua()
    {
        if (luaState != null) return;
        // new解释器
        luaState = new LuaState();
        // 启动解释器
        luaState.Start();
        // 协程相关初始化

        // 

    }

    /// <summary>
    /// 执行单条Lua语句
    /// </summary>
    /// <param name="fileName"></param>
    public void DoString(string fileName, string tips = "toLua")
    {
        InitToLua();

        luaState.DoString(fileName, tips);
    }

    /// <summary>
    /// 执行Lua文件
    /// </summary>
    /// <param name="fileName">文件名不用后缀</param>
    public void Require(string fileName)
    {
        InitToLua();

        luaState.Require(fileName);
    }

    /// <summary>
    /// 销毁解释器
    /// </summary>
    public void Dispose()
    {
        if (luaState is null) return;

        luaState.CheckTop();
        luaState.Dispose();
        luaState = null;
    }
}
