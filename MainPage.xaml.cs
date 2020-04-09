using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Data;



namespace Calculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }

        private void OnButtonClicked(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            Output.Text += button.Text;
        }
        private void OnButtonDelClicked(object sender, System.EventArgs e)
        {
            Output.Text = "";
        }

        private void OnButtonDeletionClicked(object sender, System.EventArgs e)
        {

            try
            {
                Output.Text = Output.Text.Remove((Output.Text.Length - 1), 1);
            }
            catch (Exception)
            {
                Output.Text = "";
            }
        }

        private void OnEqClicked(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            if (Output.Text.Contains("MOD"))
                Output.Text = Output.Text.Replace("MOD", "%");
            if (Output.Text.Contains(","))
                Output.Text = Output.Text.Replace(",", ".");
            try
            {
                Output.Text = Convert.ToString(new DataTable().Compute(Output.Text, null));
            }
            catch (Exception ex)
            {
                Output.Text = ex.Message;
            }

        }

        private void OnToggled(object sender, ToggledEventArgs e)
        {
            Switch switcher = (Switch)sender;
            if (switcher.IsToggled == true)
            {
                BackgroundColor = Color.Black;
                Output.TextColor = Color.White;
            }
            else
            {
                BackgroundColor = Color.White;
                Output.TextColor = Color.Black;
            }
        }


    }

}
