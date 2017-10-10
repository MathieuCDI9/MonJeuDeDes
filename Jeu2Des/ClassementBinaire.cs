using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Jeu2Des
{
    public class ClassementBinaire : Classement
    {

        public override void Save()
        {
            // Stream nécessite System.IO  
            Stream fichier = File.Create("highscores.txt");
            BinaryFormatter serialiseur = new BinaryFormatter();
            serialiseur.Serialize(fichier, this.listedentrees);
            fichier.Close();
        }
        public override void Load()
        {
            if (File.Exists("highscores.txt"))
            {
                //If vide
                Stream fichierrecup = File.OpenRead("highscores.txt");
                BinaryFormatter seriali = new BinaryFormatter();
                Object obj = seriali.Deserialize(fichierrecup);                
                this.listedentrees = (List<Entree>)obj; //TODO y revenir
                fichierrecup.Close();
            }
        }


    }
}
