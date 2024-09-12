using Microsoft.EntityFrameworkCore;
using praktikakaratpatrak.Models;
using ReactiveUI;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktikakaratpatrak.ViewModels
{
    internal class GamePageViewModel : ViewModelBase
    {
        private DbIs6113Context db = new DbIs6113Context();
        private Game currentgame;
        private Game CurrentGame
        {
            get => currentgame;
            set => this.RaiseAndSetIfChanged(ref currentgame, value);
        }
        private ObservableCollection <Game> games;
        public ObservableCollection <Game> Games 
        { 
            get => games;
            set => this.RaiseAndSetIfChanged(ref games, value); 
        }
        public void Search()
        {
            db = new DbIs6113Context();
            db.Games.Load();
            Games = db.Games.Local.ToObservableCollection();
        }
        public void Delete()
        {
            db.Games.Remove(CurrentGame);
            Games = db.Games.Local.ToObservableCollection();
            db.SaveChanges();
            Search();
        }
        public void Edit()
        {
            db.SaveChanges();
            Search();
        }
        public GamePageViewModel()
        {
            Search();
        }
    }
}
