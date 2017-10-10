using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Jeu2Des
{
    public class ClassementJSON : Classement
    {
        public override void Save()
        {
            Stream fichierin = File.Create("sav.json");
            DataContractJsonSerializer serialiseur = new DataContractJsonSerializer(listedentrees.GetType());
            serialiseur.WriteObject(fichierin, listedentrees);
            fichierin.Close();
        }

        public override void Load()
        {
            if (File.Exists("sav.json"))
            {
                Stream fichierout = File.OpenRead("sav.json");
                DataContractJsonSerializer serialKiller = new DataContractJsonSerializer(typeof(List<Entree>));
                this.listedentrees = (List<Entree>)serialKiller.ReadObject(fichierout);
                //Console.Out.WriteLine(listedentrees);

                fichierout.Close();
            }
        }



    }
}
