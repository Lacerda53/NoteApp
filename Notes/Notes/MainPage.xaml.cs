using System;
using System.IO;
using Xamarin.Forms;

namespace Notes
{
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

        public MainPage()
        {
            InitializeComponent();
            //Animation();

            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
            }
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(editor.Text))
            {
                DisplayAlert("Ops", "Nenhuma anotação foi feita", "OK");
            }
            else
            {
                File.WriteAllText(_fileName, editor.Text);
                DisplayAlert("Anotado", "Suas anotações foram salvas", "OK");
            }

        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
                DisplayAlert("Apagado", "Suas anotações foram apagadas", "OK");
            }
            editor.Text = string.Empty;
        }

        public async void Animation()
        {
            await editor.FadeTo(1, 1000, Easing.SinInOut);
            await salvar.FadeTo(1, 1000, Easing.BounceIn);
            await cancelar.FadeTo(1, 1000, Easing.BounceIn);
        }
    }
}
