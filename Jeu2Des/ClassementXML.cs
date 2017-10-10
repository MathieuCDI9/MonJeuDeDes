using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Jeu2Des
{
    public class ClassementXML : Classement
    {

        public override void Save()
        {
            Stream fichi = File.Create("Save_Me.xml");
            XmlSerializer serialo = new XmlSerializer(listedentrees.GetType());
            serialo.Serialize(fichi, listedentrees);
            fichi.Close();
        }

        public override void Load()
        {
            if (File.Exists("Save_Me.xml"))
            {
                Stream fichtre = File.OpenRead("Save_Me.xml");
                XmlSerializer serijeanmichel = new XmlSerializer(listedentrees.GetType());
                object monobjet = serijeanmichel.Deserialize(fichtre);
                //Console.WriteLine(monobjet);



                this.listedentrees = (List<Entree>)monobjet; //TODO y revenir
                fichtre.Close();

            }
        }
    }
}
