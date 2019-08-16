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
            Animation();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename))
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
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                // Update
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(note.Filename, note.Text);
                await Navigation.PopAsync();
            }

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
        public async void Animation()
        {
            await editor.FadeTo(1, 1000, Easing.SinInOut);
            await salvar.FadeTo(1, 1000, Easing.BounceIn);
            await cancelar.FadeTo(1, 1000, Easing.BounceIn);
        }
    }
}