using System;
using System.IO;
using Xamarin.Forms;
using Notes.Models;

namespace Notes
{
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await editor.FadeTo(1, 500, Easing.Linear);
            await salvar.FadeTo(1, 300, Easing.Linear);
            await cancelar.FadeTo(1, 300, Easing.Linear);
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            if (string.IsNullOrEmpty(editor.Text))
            {
                uint timeout = 50;
                await editor.TranslateTo(-15, 0, timeout);
                await editor.TranslateTo(15, 0, timeout);
                await editor.TranslateTo(-10, 0, timeout);
                await editor.TranslateTo(10, 0, timeout);
                await editor.TranslateTo(-5, 0, timeout);
                await editor.TranslateTo(5, 0, timeout);
                editor.TranslationX = 0;
                await DisplayAlert("Ops", "Nenhuma anotação foi feita", "OK");
            }
            if (!string.IsNullOrWhiteSpace(note.Filename))
            {
                File.WriteAllText(note.Filename, note.Text);
            }
            await Navigation.PopAsync();

        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
                await DisplayAlert("Apagado", "Suas anotações foram apagadas", "OK");
            }

            await Navigation.PopAsync();
        }
    }
}