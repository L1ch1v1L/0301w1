using Microsoft.EntityFrameworkCore;
using praktikakaratpatrak.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktikakaratpatrak.ViewModels
{
    internal class GenrePageViewModel : ViewModelBase
    {
        private DbIs6113Context db = new DbIs6113Context();
        private Genre currentgenre;
        public Genre CurrentGenre
        {
            get => currentgenre;
            set => this.RaiseAndSetIfChanged(ref currentgenre, value);
        }

        private ObservableCollection<Genre> genres;
        public ObservableCollection<Genre> Genres
        {
            get => genres;
            set => this.RaiseAndSetIfChanged(ref genres, value);
        }

        public void Search()
        {
            db = new DbIs6113Context();
            db.Genres.Load();
            Genres = db.Genres.Local.ToObservableCollection();
        }

        public void Delete()
        {
            db.Genres.Remove(CurrentGenre);
            Genres = db.Genres.Local.ToObservableCollection();
            db.SaveChanges();
            Search();
        }
        public void Edit()
        {
            db.SaveChanges();
            Search();
        }
        public GenrePageViewModel()
        {
            Search();
        }
    }
}
