using System;
using System.Collections.Generic;
using System.Text;

namespace ТпЛр2.Modeli
{
    public class Composition : Interface
    {
        string _name, _kategorie;
        int _preis, _comfortofuse;
        public string Name; 
        public string Kategorie; 
        public int Preis;
        public int Comfortofuse;
        public Composition()
        {
            _name = Name;
            _kategorie = Kategorie;
            _preis = Preis;
            _comfortofuse = Comfortofuse;
        }
        public string name { get => _name; set => _name = value; }
        public string kategorie { get => _kategorie; set => _kategorie = value; }
        public int preis { get => _preis; set => _preis = value; }
        public int comfortofuse { get => _comfortofuse; set => _comfortofuse = value; }
    }
}
