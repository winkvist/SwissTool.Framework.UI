// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowManager.cs" company="Fredrik Winkvist">
//   Copyright (c) Fredrik Winkvist. All rights reserved.
// </copyright>
// <summary>
//   Defines the WindowHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SwissTool.Framework.UI.Managers
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;

    using SwissTool.Framework.UI.Infrastructure;
    using SwissTool.Framework.UI.Models;

    /// <summary>
    /// A window helper class.
    /// </summary>
    public static class WindowManager
    {
        /// <summary>
        /// Gets the current theme.
        /// </summary>
        /// <value>
        /// The current theme.
        /// </value>
        public static Theme CurrentTheme { get; internal set; }

        /// <summary>
        /// Gets the current accent.
        /// </summary>
        /// <value>
        /// The current accent.
        /// </value>
        public static string CurrentAccent { get; internal set; }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="viewModel">The view model.</param>
        /// <param name="setFocus">Automatically sets focus if set to <c>true</c>.</param>
        /// <param name="owner">The window owner.</param>
        /// <returns>The dialog result.</returns>
        public static bool? ShowDialog<TView>(ViewModelBase viewModel, bool setFocus = true, Window owner = null) 
            where TView : Window, new()
        {
            var view = new TView { DataContext = viewModel, Owner = owner };
            viewModel.RequestClose += view.Close;

            if (setFocus)
            {
                SetFocus(view);
            }

            bool? result;

            try
            {
                result = view.ShowDialog();
            }
            finally
            {
                viewModel.RequestClose -= view.Close;
            }

            return result;
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="setFocus">if set to <c>true</c> [set focus].</param>
        /// <param name="owner">The owner.</param>
        /// <returns>The dialog result.</returns>
        public static bool? ShowDialog<TView, TViewModel>(bool setFocus = true, Window owner = null) 
            where TView : Window, new()
            where TViewModel : ViewModelBase, new()
        {
            var viewModel = new TViewModel();
            return ShowDialog<TView>(viewModel, setFocus, owner);
        }

        /// <summary>
        /// Sets focus to a specific window.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns>A value indicating whether the windows was focused.</returns>
        public static bool SetFocus(Window window)
        {
            return SetForegroundWindow(new WindowInteropHelper(window).EnsureHandle());
        }

        /// <summary>
        /// Sets the foreground window.
        /// </summary>
        /// <param name="hWnd">The window handle.</param>
        /// <returns>A value indicating whether the window was focused.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
