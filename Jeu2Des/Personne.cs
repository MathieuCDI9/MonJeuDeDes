using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;



namespace testSerialisation
{
    [DataContract]
    //[Serializable]
    
    public class Personne
    {
        private string _Nom;
        private string _Prenom;
        [DataMember]
        public string Nom
        {
            get{ return _Nom; }
            set { _Nom = value; }
        }
        [DataMember]
        public string Prenom
        {
            get { return _Prenom; }
            set { _Prenom = value; }
        }

        public Personne()
        {
            this._Nom = "Majax";
            this._Prenom = "Roger";
        }
        public Personne(string nom, string prenom)
        {
            _Nom = nom;
            _Prenom = prenom;
        }

        public override string ToString()
        {
            return base.ToString() + " " + Nom + " " + Prenom ;
        }


    }
}
