﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile_Cust_LstViews.Models;
using Xamarin.Forms;

namespace Mobile_Cust_LstViews
{
    public partial class MainPage : ContentPage
    {
        private List<Song> _songs;
        private CustomListView _songListView;

        public MainPage()
        {
            //InitializeComponent();
            InitializeDummyData();
            _songListView = new CustomListView(ListViewCachingStrategy.RetainElement, _songs);
            _songListView.ItemsSource = _songs;
            _songListView.RowHeight = 100;
            Content = _songListView;
        }

        private void InitializeDummyData()
        {
            _songs = new List<Song>()
            {
                new Song() {Artist = "Red warszawa", Album = "Heavy metal og hash", Title = "Julemandens selvmordsbrev", BPM = 120, IsFavorite = true,YearReleased = 1994},
                new Song() {Artist = "Red warszawa", Album = "Heavy metal og hash", Title = "Dødshimlen", BPM = 140, IsFavorite = false,YearReleased = 1994},
                new Song() {Artist = "Puscifer", Album = "Conditions of my Parole", Title = "Horizon", BPM = 108, IsFavorite = true,YearReleased = 2008},
                new Song() {Artist = "Puscifer", Album = "Donkey Punched the Night Away(EP)", Title = "Dear Brother", BPM = 110, IsFavorite = false,YearReleased = 1994},
                new Song() {Artist = "Red warszawa", Album = "Heavy metal og hash", Title = "Dødshimlen", BPM = 140, IsFavorite = false,YearReleased = 1994},
                new Song() {Artist = "Red warszawa", Album = "Heavy metal og hash", Title = "Dødshimlen", BPM = 140, IsFavorite = false,YearReleased = 1994},
                new Song() {Artist = "Red warszawa", Album = "Heavy metal og hash", Title = "Dødshimlen", BPM = 140, IsFavorite = true,YearReleased = 1994},
                new Song() {Artist = "Red warszawa", Album = "Heavy metal og hash", Title = "Dødshimlen", BPM = 140, IsFavorite = false,YearReleased = 1994},
            };
        }
    }

    class CustomListView : ListView
    {
        private List<Song> _songs;
        public CustomListView(ListViewCachingStrategy strategy, List<Song> songs) : base(strategy)
        {
            _songs = songs;
            ItemTemplate = new DataTemplate(typeof(SongCell));
        }

        protected override void SetupContent(Cell content, int index)
        {
            base.SetupContent(content, index);
            SongCell currentViewCell = content as SongCell;
            if (currentViewCell != null)
            {
                currentViewCell.View.BackgroundColor = index % 2 == 0 ? Color.Blue : Color.Aqua;
                currentViewCell.SetFavorite(_songs[index].IsFavorite);
            }
        }
    }

    class SongCell : ViewCell
    {
        private StackLayout _cellLayout;
        private StackLayout _desciptionStack;
        private StackLayout _metaData1;
        private StackLayout _metaData2;

        private Image _isFavorite;
        Label _title;
        Label _artist;
        Label _album;
        Label _yearReleased;
        Label _bpm;

        public SongCell()
        {
            //Initializing View Objects
            _cellLayout = new StackLayout();
            _desciptionStack = new StackLayout();
            _metaData1 = new StackLayout();
            _metaData2 = new StackLayout();

            _title = new Label();
            _artist = new Label();
            _album = new Label();
            _yearReleased = new Label();
            _bpm = new Label();
            _isFavorite = new Image();

            _title.SetBinding(Label.TextProperty, "Title");
            _artist.SetBinding(Label.TextProperty, "Artist");
            _album.SetBinding(Label.TextProperty, "Album");
            _yearReleased.SetBinding(Label.TextProperty, "YearReleased");
            _bpm.SetBinding(Label.TextProperty, "BPM");

            //Setting Layout Orientation
            _cellLayout.Orientation = StackOrientation.Horizontal;
            _desciptionStack.Orientation = StackOrientation.Horizontal;
            _metaData1.Orientation = StackOrientation.Vertical;
            _metaData2.Orientation = StackOrientation.Vertical;

            _desciptionStack.Children.Add(_metaData1);
            _desciptionStack.Children.Add(_metaData2);
            _cellLayout.Children.Add(_desciptionStack);
            _cellLayout.Children.Add(_isFavorite);

            _metaData1.Children.Add(_title);
            _metaData1.Children.Add(_artist);
            _metaData1.Children.Add(_album);
            _metaData2.Children.Add(_yearReleased);
            _metaData2.Children.Add(_bpm);

            View = _cellLayout;
        }

        public void SetFavorite(bool isFavorite)
        {
            
            _isFavorite.Source = isFavorite ? "up.png" : "down.png";
        }
    }
}