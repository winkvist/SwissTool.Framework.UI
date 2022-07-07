// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetroDialogWindow.cs" company="Fredrik Winkvist">
//   Copyright (c) Fredrik Winkvist. All rights reserved.
// </copyright>
// <summary>
//   Defines the MetroDialogWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SwissTool.Framework.UI.Controls
{
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    using MahApps.Metro.Controls;

    /// <summary>
    /// The metro dialog window.
    /// </summary>
    /// <seealso cref="MahApps.Metro.Controls.MetroWindow" />
    public partial class MetroDialogWindow : MetroWindow
    {
        /// <summary>
        /// The Heading property.
        /// </summary>
        private static readonly DependencyProperty HeadingProperty = DependencyProperty.Register("Heading", typeof(string), typeof(MetroDialogWindow));

        /// <summary>
        /// The description property.
        /// </summary>
        private static readonly DependencyProperty SubHeadingProperty = DependencyProperty.Register("SubHeading", typeof(string), typeof(MetroDialogWindow));

        /// <summary>
        /// The footer text property
        /// </summary>
        private static readonly DependencyProperty FooterTextProperty = DependencyProperty.Register("FooterText", typeof(string), typeof(MetroDialogWindow));

        /// <summary>
        /// The show cancel button property.
        /// </summary>
        private static readonly DependencyProperty ShowCancelButtonProperty = DependencyProperty.Register("ShowCancelButton", typeof(bool), typeof(MetroDialogWindow));

        /// <summary>
        /// The image property.
        /// </summary>
        private static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(MetroDialogWindow));

        /// <summary>
        /// The accept command.
        /// </summary>
        private static readonly DependencyProperty AcceptCommandProperty = DependencyProperty.Register("AcceptCommand", typeof(ICommand), typeof(MetroDialogWindow));

        /// <summary>
        /// The cancel command.
        /// </summary>
        private static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(MetroDialogWindow));

        /// <summary>
        /// The accept command label property
        /// </summary>
        private static readonly DependencyProperty AcceptCommandLabelProperty = DependencyProperty.Register("AcceptCommandLabel", typeof(string), typeof(MetroDialogWindow), new PropertyMetadata("OK"));


        /// <summary>
        /// Initializes static members of the <see cref="MetroDialogWindow"/> class.
        /// </summary>
        static MetroDialogWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroDialogWindow), new FrameworkPropertyMetadata(typeof(MetroDialogWindow)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetroDialogWindow"/> class.
        /// </summary>
        public MetroDialogWindow()
        {
            this.BorderThickness = new Thickness(1);
            this.BorderBrush = (Brush)this.FindResource("MahApps.Brushes.Accent");
        }
        
        /// <summary>
        /// Gets or sets the Heading.
        /// </summary>
        /// <value>The Heading.</value>
        public string Heading
        {
            get => (string)this.GetValue(HeadingProperty);
            set => this.SetValue(HeadingProperty, value);
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The Heading.</value>
        public string SubHeading
        {
            get => (string)this.GetValue(SubHeadingProperty);
            set => this.SetValue(SubHeadingProperty, value);
        }

        /// <summary>
        /// Gets or sets the footer text.
        /// </summary>
        /// <value>
        /// The footer text.
        /// </value>
        public string FooterText
        {
            get => (string)this.GetValue(FooterTextProperty);
            set => this.SetValue(FooterTextProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show cancel button].
        /// </summary>
        /// <value><c>true</c> if [show cancel button]; otherwise, <c>false</c>.</value>
        public bool ShowCancelButton
        {
            get => (bool)this.GetValue(ShowCancelButtonProperty);
            set => this.SetValue(ShowCancelButtonProperty, value);
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public ImageSource Image
        {
            get => (ImageSource)this.GetValue(ImageProperty);
            set => this.SetValue(ImageProperty, value);
        }

        /// <summary>
        /// Gets or sets the accept command.
        /// </summary>
        /// <value>The accept command.</value>
        public ICommand AcceptCommand
        {
            get => (ICommand)this.GetValue(AcceptCommandProperty);
            set => this.SetValue(AcceptCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the cancel command.
        /// </summary>
        /// <value>The cancel command.</value>
        public ICommand CancelCommand
        {
            get => (ICommand)this.GetValue(CancelCommandProperty);
            set => this.SetValue(CancelCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the accept command label.
        /// </summary>
        /// <value>The title.</value>
        public string AcceptCommandLabel
        {
            get => (string)this.GetValue(AcceptCommandLabelProperty);
            set => this.SetValue(AcceptCommandLabelProperty, value);
        }
    }
}
