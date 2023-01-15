using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace test_101
{
    [DesignTimeVisible(false)]
    public partial class VideoPlayerPage : ContentPage
    {
        public VideoPlayerPage(string SVURL, string PPTitle)
        {
             InitializeComponent();
            Title = PPTitle;
            DPVideoPlayer.Source = SVURL;
            // PlayerpageTitle.Title = PPT;
        }
        
    }
}

