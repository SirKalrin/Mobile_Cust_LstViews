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
        private List<Song> _songs = new List<Song>();
        private CustomListView _songListView = new CustomListView(ListViewCachingStrategy.RetainElement, _songs);

        public MainPage()
        {
            InitializeComponent();
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
        
    }
}
