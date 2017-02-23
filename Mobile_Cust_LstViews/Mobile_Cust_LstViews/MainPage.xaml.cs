using System;
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
            InitializeComponent();
            _songs = new List<Song>();
            _songListView = new CustomListView(ListViewCachingStrategy.RetainElement, _songs);
        }


    }

    class CustomListView : ListView
    {

        public CustomListView(ListViewCachingStrategy strategy, List<Song> songs) : base(strategy)
        {
            
        }

        protected override void SetupContent(Cell content, int index)
        {
            base.SetupContent(content, index);
        }
    }

    class SongCell : ViewCell
    {
        private StackLayout _cellLayout;
        private StackLayout _desciptionStack;
        private StackLayout _metaData1;
        private StackLayout _metaData2;

        private Image _isFavorite;


        public SongCell()
        {
            //Initializing View Objects
            _cellLayout = new StackLayout();
            _desciptionStack = new StackLayout();
            _metaData1 = new StackLayout();
            _metaData2 = new StackLayout();



            //Setting Layout Orientation
            _cellLayout.Orientation = StackOrientation.Horizontal;
            _desciptionStack.Orientation = StackOrientation.Horizontal;
            _metaData1.Orientation = StackOrientation.Vertical;
            _metaData2.Orientation = StackOrientation.Vertical;
        }

    }
}
