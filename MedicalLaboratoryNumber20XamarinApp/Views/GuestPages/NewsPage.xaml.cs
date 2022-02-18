using MedicalLaboratoryNumber20XamarinApp.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalLaboratoryNumber20XamarinApp.Views.GuestPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
            NewsView.ItemsSource = new List<ResponseNews>
            {
                new ResponseNews
                {
                    Title = Guid.NewGuid().ToString(),
                    PublicationDate = DateTime.Now,
                    NewsText = string.Join("", Enumerable.Repeat(Guid.NewGuid().ToString(), 10))
                },
                new ResponseNews
                {
                    Title = Guid.NewGuid().ToString(),
                    PublicationDate = DateTime.Now,
                    NewsText = string.Join("", Enumerable.Repeat(Guid.NewGuid().ToString(), 10))
                },
                new ResponseNews
                {
                    Title = Guid.NewGuid().ToString(),
                    PublicationDate = DateTime.Now,
                    NewsText = string.Join("", Enumerable.Repeat(Guid.NewGuid().ToString(), 10))
                },
                new ResponseNews
                {
                    Title = Guid.NewGuid().ToString(),
                    PublicationDate = DateTime.Now,
                    NewsText = string.Join("", Enumerable.Repeat(Guid.NewGuid().ToString(), 10))
                },
            }.OrderBy(n => n.PublicationDate);
        }

        private void OnNewsRefreshing(object sender, EventArgs e)
        {

        }
    }
}