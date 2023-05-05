using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextData
{ 
    /// <summary>
    /// 数据类
    /// </summary>
    public class Data
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int id;
        /// <summary>
        /// 对话内容
        /// </summary>
        public string des;
        /// <summary>
        /// 正在对话人的名字
        /// </summary>
        public string name;
        /// <summary>
        /// 背景
        /// </summary>
        public string BGurl;
        /// <summary>
        /// 背景音乐
        /// </summary>
        public string bgmUrl;
        /// <summary>
        /// 声优音效
        /// </summary>
        public string voiceUrl;
        /// <summary>
        /// 角色立绘数组
        /// </summary>
        public string playerPaint;
    }
}