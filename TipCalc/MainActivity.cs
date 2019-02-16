using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace TipCalc
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            var SBPercent = FindViewById<SeekBar>(Resource.Id.sbPercent);
            var TextTip = FindViewById<TextView>(Resource.Id.textTip);
            var TextSum = FindViewById<TextView>(Resource.Id.textSumInt);
            var TextBill = FindViewById<EditText>(Resource.Id.textBillInt);
            double bill = 0;
            double percent = 0;
            

            TextBill.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                bill = Convert.ToInt32(TextBill.Text);
                TextSum.Text = (bill / 100*percent + bill).ToString() + "€";
            };

            SBPercent.ProgressChanged += (s, e) => {
                TextTip.Text = string.Format("Jootraha soovin jätta {0} %", e.Progress);
                percent = e.Progress;
                TextSum.Text = (bill / 100 * percent + bill).ToString() + "€";
            };
        }
    }
}