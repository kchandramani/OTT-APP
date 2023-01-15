using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using static test_101.Model.Movie;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using test_101.Model;
using System.Linq;
using Xamarin.Forms.PlatformConfiguration;

namespace test_101
{
    public partial class MainPage : ContentPage
    {

        //private Command itemTappedCommand; //for tap recogniser
        public MainPage()
        {
           
            InitializeComponent();
           // itemTappedCommand = new Command(OnItemTapped);

            _ =GetJsonAsync();
           

        }



        //testing tap reogniser for every grid in collection view







        //public Command ItemTappedCommand
        //{
        //    get { return itemTappedCommand; }
        //    protected set { itemTappedCommand = value; }
        //}

        
        //public void OnItemTapped(object obj)
        //{
        //    var itemData = obj as Movie;
        //    App.Current.MainPage.DisplayAlert("Message", "Tapped item data: " + itemData.title, "OK");
        //}















        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    if (testListView.SelectedItem == null)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        testListView.SelectedItem = null;
        //        testListView2.SelectedItem = null;
        //    }
        //    //your code here;
        //    // CollectionView.SelectionChangedCommandParameterProperty.DefaultValue.Equals();
        //}

        //protected virtual void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    testListView.SelectedItem = null;
        //    testListView2.SelectedItem = null;
        //}








        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // var Sender = sender as CollectionView;
            

            if (e.CurrentSelection != null)
            {
                var Sender = sender as CollectionView;

                if (Sender.SelectedItem == null)
                { return;  }

                // Navigate to the NoteEntryPage, passing the filename as a query parameter.
                Movie VideoDetails = (Movie)e.CurrentSelection.FirstOrDefault();

                await Navigation.PushAsync(new MovieDetailsPage(VideoDetails.title, VideoDetails.posterUrl, VideoDetails.shortSummary, VideoDetails.year, VideoDetails.runTime, VideoDetails.rating, VideoDetails.StreamUrls));

                //  ((CollectionView)sender).SelectedItem = null;


              //  await Task.Delay(1000);
                Sender.SelectedItem = null;
            }






            //else
            //{
            //    testListView.SelectedItem = null;
            //    testListView2.SelectedItem = null;
            //}


            //testListView2.SelectedItem = 0;
            // testListView.SelectedItems.Clear();
            //((CollectionView)sender).SelectedItem = null;


        }


        List<Movie> modelList1 = new List<Movie>();
        List<Movie> modelList2 = new List<Movie>();
         List<string> Categories = new List<string>();
        //Dictionary<string, string> frontPD = new Dictionary<string, string>();
        //Dictionary<string, string> frontPD2 = new Dictionary<string, string>();
        //string Subscriptions;



        public async Task GetJsonAsync()
        {
           // IsBusy = true;
            var uri = new Uri("https://hargray-tv-staging.tv2consulting.com/vod/assets");

            HttpClient httpClient = new HttpClient();

            string token = "JWT eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IlZUajZ6T0l1SlYzeHEzUXZGazY4c2Z1RGM4TjhlZWotbzVYMEZjTmtvZUkifQ.eyJhdWQiOiJoYXItdmEiLCJleHAiOjE2NjI0NzUzMjAsImlhdCI6MTY2MDA1NjEyMCwiaW50ZWdyaXR5Ijoia0o0VnN2TkRuT3MiLCJpc3MiOiJodHRwczovL2hhcmdyYXktYXV0aC50djJjb25zdWx0aW5nLmNvbSIsImp0aSI6ImZySDJHODQ0cWt-ckdSVHdITXBubWlVZUZ1RnNySVpPQnljfmxKV3N2eG4iLCJzdWIiOjEwMDA1NzI5MjgsInRva2VuX3R5cGUiOiJhY2Nlc3NfdG9rZW4iLCJjbGFpbXMiOnsic3ViIjoxMDAwNTcyOTI4LCJlbWFpbCI6ImhlYWRlbmR0ZXN0MSIsIm5hbWUiOiJudWxsIEhFQURFTkQgVEVTVElORyAxIiwiaHR0cHM6Ly90djJjb25zdWx0aW5nLmNvbS9vcGVyYXRvciI6ImhhcmdyYXkiLCJodHRwczovL3R2MmNvbnN1bHRpbmcuY29tL2FjY291bnRJZCI6IjIwMDA1ODU2MTgyIn19.bnfya2VJ1pUfMxcJrPRn3Jy5vTsSPVTmICyW0RET_-6OqN2RevAlL5-7ESgcM2npD0nxlpigWrg8nVut8UJWU_gOjs03tUynzJuczyjwME_c3XEDquyAsn4_ZmUvoCeQesalnfswNF2WBuWKW5vozCeQ0aYMEcL0ATBIgHPQc7tLRcGF0B1J1ckE0ViGg0Do3ib2JTYzi5hrQZbrvzbvoU6IqwNGK8DzSspUGrLQfJDX4YXcwQwesuWaBPNkmygaQUlVa_bFJvk-J4arDtP63FVvI7iIptGMkgEXF-fPG8hN9CVV0hpIW7QSPWgv6jpkwx_GZj5OH5NIc1kp04Nh4Q";
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            httpClient.DefaultRequestHeaders.Add("Authorization", token);

            var response = await httpClient.GetAsync(uri);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Data succesfully fetched");
            // IsBusy = false;
            ac.IsRunning = false;
           // ac.IsEnabled = false;
            ac.IsVisible = false;
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string json = content.ToString();

                var jsonObject = JObject.Parse(json);

                var Data = jsonObject["result"];

                var jsonArray = JArray.Parse(Data.ToString());
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Inside 1st if (data fetched)");
                // Debug.WriteLine(Data);

               




                foreach (var insideCategory in jsonArray)  //jData is used here for traversing through the jason array.
                        {
                    
                    string Name = insideCategory["name"].ToString();
                        if(Name == "Subscriptions")
                        {
                        HeaderTitle.Text = Name;
                        // Categories

                        //string Title = insideCategory["name"].ToString();
                      //  int q = 0;
                       
                                        Console.WriteLine("-------------------------------------");
                                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("starting 2nd for Loop");
                        foreach (var assetsName in insideCategory["assets"])
                            {

                            string StreamUrls="";
                            string StreamType="";

                            Movie m = new Movie();  //object


                            string Title = assetsName["title"].ToString();

                            string PosterURL = assetsName["posterUrl"][0].ToString();

                            string Description = assetsName["shortSummary"].ToString();



                            string Year = assetsName["year"].ToString();

                            string RunTime = assetsName["runTime"].ToString();

                            string Rating = assetsName["rating"].ToString();

                            foreach (var VURL in assetsName["media"])
                            {
                                StreamType = VURL["streamType"].ToString();
                                if (StreamType == "HLS")
                                {
                                    StreamUrls = VURL["streamUrl"].ToString();
                                }

                            }

                            // 1st part
                            Console.WriteLine("storing values Inside 1st list");
                            m.title = Title;
                            m.posterUrl = PosterURL;
                           
                            m.shortSummary = Description;
                            m.year = Year;
                            m.runTime = RunTime;
                            m.rating = Rating;
                            m.StreamUrls = StreamUrls;

                            
                            


                            modelList1.Add(m);

                            Debug.WriteLine(Title);
                            Debug.WriteLine(PosterURL);
                           
                            Debug.WriteLine(Description);
                            Debug.WriteLine(Year);
                            Debug.WriteLine(RunTime);
                            Debug.WriteLine(Rating);
                            Debug.WriteLine(StreamUrls);
                            Debug.WriteLine(Name);







                        }

                    }

                        else
                            {

                        HeaderTitle2.Text = Name;

                        foreach (var assetsName in insideCategory["assets"])
                        {
                            string StreamUrls = "";
                            string StreamType = "";

                            Movie m = new Movie();
                            string Title = assetsName["title"].ToString();

                            string PosterURL = assetsName["posterUrl"][0].ToString();

                            string Description = assetsName["shortSummary"].ToString();

                            string Year = assetsName["year"].ToString();

                            string RunTime = assetsName["runTime"].ToString();

                            string Rating = assetsName["rating"].ToString();

                            foreach (var VURL in assetsName["media"])
                            {
                                StreamType = VURL["streamType"].ToString();
                                if (StreamType == "HLS")
                                {
                                    StreamUrls = VURL["streamUrl"].ToString();
                                }

                            }

                            //2nd part
                            Console.WriteLine("storing values Inside 2nd list");
                            m.title = Title;
                            m.posterUrl = PosterURL;
                            m.shortSummary = Description;
                            m.year = Year;
                            m.runTime = RunTime;
                            m.rating = Rating;
                            m.StreamUrls = StreamUrls;


                            
                            modelList2.Add(m);

                            Debug.WriteLine(Title);
                            Debug.WriteLine(PosterURL);
                           
                            Debug.WriteLine(Description);
                            Debug.WriteLine(Year);
                            Debug.WriteLine(RunTime);
                            Debug.WriteLine(Rating);
                            Debug.WriteLine(StreamUrls);
                            Debug.WriteLine(Name);













                        }



                    }

                        


                     
            }
                

            }
            else
            {
                System.Diagnostics.Debug.WriteLine("ErrorMessage ===>" + response.IsSuccessStatusCode);
            }


            testListView.ItemsSource = modelList1;
            testListView2.ItemsSource = modelList2;
            //HeaderTitle. = modelList1;
            // HeaderTitle. = modelList1;

            //foreach (KeyValuePair<string, string> url in frontPD)
            //{
            //    Console.WriteLine("Key: {0}, Value: {1}", url.Key, url.Value);
            //}
            //testListView.SelectedItems.Clear();
        }
       // protected override void OnAppearing()
        //{
        //      base.OnAppearing();
        //    testListView.SelectedItem = null;
        //    testListView2.SelectedItem = null;

        //}







    }
    
}
