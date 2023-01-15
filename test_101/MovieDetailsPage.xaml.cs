using System;
using System.Collections.Generic;
using test_101.Model;
using Xamarin.Forms;

namespace test_101
{
    public partial class MovieDetailsPage : ContentPage
    {

        string VideoURL = "";
        string VideoTitle="";
        public MovieDetailsPage(string DTitle, string DPosterUrl, string DShortSummary, string DYear, string DRunTime, string DRating, string DStreamUrl)
        {
            InitializeComponent();
            BindingContext = new MainPage();
            DPImage.Source = new UriImageSource()
            {
                Uri = new Uri(DPosterUrl)
            };
            DPImage2.Source = new UriImageSource()
            {
                Uri = new Uri(DPosterUrl)
            };
            DPDescription.Text = DShortSummary;
            DPYear.Text = DYear;
            DPRating.Text = DRating;
            DPRuntime.Text = DRunTime;
            DPTitle.Text = DTitle;

            VideoURL = DStreamUrl;
            VideoTitle = DTitle;

        }

        //async void OnImageNameTapped(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.CurrentSelection != null)
        //    {
        //        // Navigate to the NoteEntryPage, passing the filename as a query parameter.
        //        Movie VideoDetails = (Movie)e.CurrentSelection.FirstOrDefault();
        //        await Navigation.PushAsync(new MovieDetailsPage(VideoDetails.title, VideoDetails.posterUrl, VideoDetails.shortSummary, VideoDetails.year, VideoDetails.runTime, VideoDetails.rating, VideoDetails.StreamUrls));
        //    }
        //}


        //async void OnImageNameTapped(object sender, EventArgs args)
        //{
        //    try
        //    {
        //        if (args.CurrentSelection != null)
        //        {
        //            Movie VideoDetails = (Movie)args.CurrentSelection.FirstOrDefault();
        //            await Navigation.PushAsync(new MovieDetailsPage(VideoDetails.title, VideoDetails.posterUrl, VideoDetails.shortSummary, VideoDetails.year, VideoDetails.runTime, VideoDetails.rating, VideoDetails.StreamUrls));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



       

        void OnImageButtonClicked(object sender, EventArgs e)
        {
           
            Navigation.PushAsync(new VideoPlayerPage(VideoURL, VideoTitle));
                
           
        }


    }
}

