using System;
using System.Diagnostics;
using Xamarin.Forms;
using Realms;


namespace SpaceResult
{
    public partial class MainPage : ContentPage
    {
        Stopwatch stopWatch = new Stopwatch();
        private bool Running = false;
        private bool Animation_size = false;
        TimeSpan ts = new TimeSpan();
      
        public MainPage()
        {
            InitializeComponent();
          
        }

        private void ClickStart(object sender, EventArgs e)
        {
            if (!Running)
            {
                StartButton.FontSize = 25;
                ShowResult.IsVisible = false;
                Running = true;
                Run();
                stopWatch.Start();
            }
            else
            {
                Running = false;
                stopWatch.Stop();
                ShowResult.IsVisible = true;
            }



        }

        private void Run()
        {
            Device.StartTimer(TimeSpan.FromSeconds(0.001), () =>
            {
                if (Running)
                {
                    ts = stopWatch.Elapsed;
                    string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
                    StartButton.Text = elapsedTime.ToString();
                }
                return true;
            });
        }

         private void ClickReset(object sender, EventArgs e)
        {
            
            stopWatch.Restart();
            ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            StartButton.Text = elapsedTime.ToString();

            
            

        }

        private void ClickShowResult(object sender, EventArgs e)
        {
            Animation();
            RealmConfiguration realmConfiguration = new RealmConfiguration();
            Realm realm = Realm.GetInstance();

            var friend = realm.Find<DataBase>(1);
            Real.Text = friend.Name;
        }

        async private void Animation()
        {
            if (!Animation_size)
            {
                StartButton.ScaleTo(0.5, 300);
                await StartButton.TranslateTo(-120,-200,300, Easing.CubicOut);
                Animation_size = true;
            }
            else
            {
                StartButton.ScaleTo(1, 300);
                await StartButton.TranslateTo(0, 0, 300, Easing.CubicOut);
                Animation_size = false;
            }

        }
    }
}