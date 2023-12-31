﻿using System;
using System.Threading;
using System.Windows.Forms;

namespace QuestCore
{
    class ExceptionHandler
    {
        public static void Init()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException -= Handle;
            Application.ThreadException += Handle;
            AppDomain.CurrentDomain.UnhandledException -= CurrentDomain_UnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //здесь обрабатываются исключения не UI потоков
            var ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                MessageBox.Show(ex.Message, "Thread exception");
            }
            else
                MessageBox.Show(e.ExceptionObject.ToString(), "Thread exception");
        }

        static void Handle(object sender, ThreadExceptionEventArgs e)
        {
            var ex = e.Exception;
            while (ex.InnerException != null)
                ex = ex.InnerException;

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
