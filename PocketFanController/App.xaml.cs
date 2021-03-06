﻿using System.Windows;

namespace PocketFanController
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private NotifyIconWrapper _notifyIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ShutdownMode = ShutdownMode.OnExplicitShutdown;
            _notifyIcon = new NotifyIconWrapper();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            //現在の状態を保存する。(再起動時に復元できるように)
            Model.Instance.SaveLastState();

            //アプリケーション終了時にデフォルト設定に戻す。(安全のため)
            Model.Instance.SetDefault();

            base.OnExit(e);
            _notifyIcon.Dispose();
        }
    }
}