﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// 模块二：观测资源优化配置接口
/// </summary>

namespace CP.Interface.Subsys2
{
    public class MainInterface
    {
        /// <summary>
        /// 加载资源优化主要控件
        /// </summary>
        public static void AddFrameworkControl2() //CoScheduling.Main文件中函数SetFrameworkControl设置初始框架
        {
            CoScheduling.Main.MainInterface.SetFrameworkControl(Globe.m_MainForm,
                                                                Globe.m_SplashForm,
                                                                 Globe.m_StatusStrip,
                                                                 Globe.m_StatusLabel,
                                                                 Globe.m_ProgressBar,
                                                                 Globe.m_DockPane,
                                                                 Globe.m_LabelCoor);          


        }

        #region  历史事件分析


        #endregion

        #region  观测资源优化配置




        #endregion


    }
}
