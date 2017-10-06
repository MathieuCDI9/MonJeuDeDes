using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace Jeu2Des
{
    [Serializable]
    public class Classement 
    {        
        private List<Entree> _listedentrees;  

        
        public Classement()
        {
            _listedentrees = new List<Entree>();
        }        

        public void AjouterEntree(string nomjoueur, int score)
        {
            Entree entree = new Entree(nomjoueur, score);
            _listedentrees.Add(entree);
        }
//-------------------------------!!!!!!! FACTORISATION DE CODE  !!!!!!!!!!!!!!!!!!!!!!!!!-------------------------
        //public void AfficherClassement()
        //{
        //    int place = 0;
        //    _listedentrees.Sort();
        //    _listedentrees.Reverse();
        //    foreach (Entree item in _listedentrees)
        //    {
        //        place = place + 1;
        //        string Rank = place + " : " ;
        //        Console.WriteLine(Rank + item);
        //    }
        //}
        //---------------------La méthode suivante s'appelait à l'origine AfficherClassement(5)... mettre une variable
        //---------------------en paramétre est bien plus indiqué. 
        public void TopN (int n)
        {
            int place = 0;
            _listedentrees.Sort();
            _listedentrees.Reverse();
            _listedentrees = _listedentrees.GetRange(0, n);
            foreach (Entree item in _listedentrees)
            {
                place = place + 1;
                string Rank = place + " : ";
                Console.WriteLine(Rank + item);
            }
        }
        //---------------Factoriser le code consiste à n'écrire qu'une seule fois les choses en appelant dans le constructeur 
        //---------------par défaut qui suit, le constructeur monoparamétré en lui glissant en paramétre un int comme le count 
        //---------------de la liste (ce qui ne justifie plus le nom de la méthode mais bon
        public void TopN()
        {
            TopN(_listedentrees.Count());
        }

        public void Save()
        {
            // Stream nécessite System.IO  
            Stream fichier = File.Create("highscores.txt");
            BinaryFormatter serialiseur = new BinaryFormatter();
            serialiseur.Serialize(fichier, this._listedentrees);
            fichier.Close();
        }
        public void Load()
        {
            if (File.Exists("highscores.txt"))
            {
                //If vide
                Stream fichierrecup = File.OpenRead("highscores.txt");
                BinaryFormatter seriali = new BinaryFormatter();
                Object obj = seriali.Deserialize(fichierrecup);
                Console.WriteLine(obj);
                this._listedentrees = (List<Entree>)obj; //TODO y revenir
                fichierrecup.Close();
                this.TopN();

            }

        }
        [Serializable]
        public class Entree : IComparable
        {
            private string _Nom;
            private int _Score;

            public string Nom
            {
                get { return _Nom; }
                set { _Nom = value; }
            }
            public int Score
            {
                get { return _Score; }
                set { _Score = value; }
            }
            public Entree(string nomjoueur, int score)
            {
                _Nom = nomjoueur;
                _Score = score;
            }

            public int CompareTo(Object other)
            {
                if (other == null) return 1;

                Entree entree = other as Entree;
                if (entree != null)
                    return Score.CompareTo(entree.Score);
                else
                    return 1;
            }

            //todo to string 

            public override string ToString()
            {
                return /*base.ToString() + " " +*/ Nom + " " + Score;
            }
        }
    }
}
