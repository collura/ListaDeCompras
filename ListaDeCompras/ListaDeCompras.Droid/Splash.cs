using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Content.PM;
using Android.Widget;

namespace ListaDeCompras.Droid
{
    [Activity(Theme = "@style/Splash", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, NoHistory = true)]
    public class Splash : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            System.Threading.Thread.Sleep(2000);
            StartActivity(typeof(MainActivity));
        }
    }
}