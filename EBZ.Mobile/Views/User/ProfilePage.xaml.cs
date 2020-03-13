﻿using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EBZ.Mobile.Views.User
{
    /// <summary>
    /// Page to show the article profile
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilePage" /> class.
        /// </summary>
        public ProfilePage()
        {
            this.InitializeComponent();
        }
    }
}