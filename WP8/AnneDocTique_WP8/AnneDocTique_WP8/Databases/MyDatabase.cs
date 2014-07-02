using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnneDocTique_WP8.Databases
{
    public class AnecdoteDB : DataContext
    {
        public static string DBConnectionString = "Data Source=isostore:/AnecdoteDB.sdf";

        public AnecdoteDB(string connectionString) : base(connectionString) { }

        public Table<Filtres> FiltresDB;
        public Table<Favoris> FavorisDB;
    }

    [Table(Name = "Filtres")]
    public class Filtres
    {
        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public string Nom { get; set; }
        [Column]
        public bool Value { get; set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the page that a data context property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }

    [Table(Name = "Favoris")]
    public class Favoris
    {
        [Column(IsPrimaryKey = true, CanBeNull = false, IsDbGenerated = true)]
        public int ID { get; set; }
        [Column]
        public string Content { get; set; }
        [Column]
        public string Type { get; set; }
        [Column]
        public string Date { get; set; }
        [Column]
        public string Author { get; set; }
        [Column]
        public string Vote1 { get; set; }
        [Column]
        public string Vote2 { get; set; }
        [Column]
        public string Color1 { get; set; }
        [Column]
        public string Color2 { get; set; }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the page that a data context property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
