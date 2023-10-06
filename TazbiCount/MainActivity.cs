using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Collections.Generic;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace TazbiCount
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView countView; // Use "countView" as the TextView variable name
        long number;


        private Button resatBtn;
        private int count = 0;

        private Button saveBtn; // Add a "Save" button
        private ListView saveList; // Use a ListView for displaying saved values
        private List<string> savedValues = new List<string>(); // List to store saved values
        private ArrayAdapter<string> adapter; // ArrayAdapter to bind the savedValues list to the ListView

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            countView = FindViewById<TextView>(Resource.Id.countView);
            
            FindViewById<Button>(Resource.Id.addingBtn).Click += (s,e) =>
            countView.Text = (++number).ToString(); // Use for Adding Number

            resatBtn = FindViewById<Button>(Resource.Id.resatBtn);
            countView.Text = count.ToString(); // Resat For Starting new Number Start
       
            countView.Text = number.ToString();
            resatBtn = FindViewById<Button>(Resource.Id.resatBtn);
            countView.Text = count.ToString();
            resatBtn.Click += ResatBtn_Click;

            countView.Text = number.ToString(); // Reset For Starting new Number Start

            saveBtn = FindViewById<Button>(Resource.Id.savebtn);
            saveBtn.Click += SaveBtn_Click;

            saveList = FindViewById<ListView>(Resource.Id.saveList); // Initialize the ListView

            // Create an ArrayAdapter to bind the savedValues list to the ListView
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, savedValues);
            saveList.Adapter = adapter;


            void ResatBtn_Click(object sender, System.EventArgs e)
            {
                // Reset the counter to zero
                number = 0;

                // Update the "countView" to show the new counter value
                countView.Text = number.ToString();
            }

             void SaveBtn_Click(object sender, System.EventArgs e)
            {
                // Add the current counting value to the savedValues list
                savedValues.Add(number.ToString());

                // Notify the adapter that the dataset has changed
                adapter.NotifyDataSetChanged();

                // Optionally, you can clear the counting value after saving
                number = 0;
                countView.Text = number.ToString();
            }


        }
    


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
      
    }
}