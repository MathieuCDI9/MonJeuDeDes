using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Jeu2Des;
using System.Xml.Serialization;
using testSerialisation;
using System.Runtime.Serialization.Json;

namespace Testeur
{
    class Testeur
    {
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans un jeu de dés un peu particulier. 1 seul joueur et 2 dés sont nécessaires. Si vous faites 7, 10 points vous seront attribués. Au bout de 10 lancers, le jeu s'arrête et calcule votre score.");
                  

            bool saisieIsValid = false;
            int choix = -1;
            while (!saisieIsValid)
            {
                Console.WriteLine("Voici le classement. Saisissez \"1\" si vous voulez la version binaire, \"2\" la version XML. N'importe quel autre chiffre chargera le classement version JSON");
                string saisie = Console.ReadLine();
                if (int.TryParse(saisie, out choix))
                    saisieIsValid = true;
                else
                {
                    saisieIsValid = false;
                    Console.WriteLine("La touche saisie n'est pas un chiffre");
                }
            }          

            //Le jeu est crée (avec ses 2 des et son classement)
            Jeu MonJeu = new Jeu(choix);

            MonJeu.VoirClassement(10);
            
            //MonJeu.VoirClassement();
            Console.ReadKey();         

            

            Console.WriteLine("C'est maintenant à vous de jouer. Invoquez la chance pour intégrer ce prestigieux classement !!! :)");

            

            Console.WriteLine("Entrez votre pseudo et validez avec la touche \"Entrée\"");
            string pseudo = Console.ReadLine();
            Console.WriteLine("Vous allez jouer avec le pseudo : " + pseudo + ". Appuyez sur \"Entrée\"");

            Console.ReadKey();

            int resultat = MonJeu.JouerPartie(pseudo);
            Console.WriteLine("Votre score est de "+ resultat + ". Appuyez sur \"Entrée\"");

            Console.ReadKey();
            ////Jouons quelques parties....
            //MonJeu.JouerPartie(); //1ere partie avec un joueur par défaut
            //MonJeu.JouerPartie(); //2eme partie avec un joueur par défaut
            //MonJeu.JouerPartie("David"); //3eme partie
            //MonJeu.JouerPartie("David"); //Encore une partie  
            //MonJeu.JouerPartie("Sarah"); //Encore une partie 
            //MonJeu.JouerPartie("Lucie"); //Encore une partie
            //MonJeu.JouerPartie("Johnny"); //Encore une partie 
            //MonJeu.JouerPartie("BeGood"); //Encore une partie 
            //MonJeu.JouerPartie("John"); //Encore une partie 
            //MonJeu.JouerPartie("Dédé"); //Encore une partie 
            Console.WriteLine("Voyons si vous apparaissez dans le nouveau classement...");
            MonJeu.VoirClassement(10);
            //Console.ReadKey();

            //Console.ReadLine();
            //MonJeu.VoirClassement(5);

            MonJeu.Quitter();

            //MonJeu.Classement.AfficherClassement();

            // MonJeu.Classement.TopN();


            // --------- Serialisation binaire -----------------------------------------------------------------

            //if (File.Exists("sauver.txt"))
            //{
            //    Stream fich = File.OpenRead("sauver.txt");
            //    BinaryFormatter serial = new BinaryFormatter();
            //    Object obj = serial.Deserialize(fich);
            //    Console.WriteLine(obj);
            //    Personne p = (Personne)obj;
            //    Console.WriteLine(p);
            //    fich.Close();
            //}

            //Personne p1 = new Personne("Jeannot");
            //Console.WriteLine(p1);
            //Stream fichier = new FileStream("sauver.txt", FileMode.Create);
            //BinaryFormatter serializer = new BinaryFormatter();
            //serializer.Serialize(fichier, p1);
            //fichier.Close();


            //--------- Serialisation XML ----------------------------------------------------------------------

            //Stream fichtre = File.OpenRead("Save_Me.xml");
            //XmlSerializer serijeanmichel = new XmlSerializer(typeof(List<Personne>));
            //Object monobjet = serijeanmichel.Deserialize(fichtre);
            //Console.WriteLine(monobjet);
            //fichtre.Close();

            //Console.ReadKey();

            //Personne p850 = new Personne("Safa");
            //Personne p851 = new Personne("Daridon");
            //List<Personne> lstpersonnes = new List<Personne>();
            //lstpersonnes.Add(p850);
            //lstpersonnes.Add(p851);
            //Stream fichi = File.Create("Save_Me.xml");
            //XmlSerializer serialo = new XmlSerializer(lstpersonnes.GetType());
            //serialo.Serialize(fichi, lstpersonnes);

            //fichi.Close();

            //--------- Serialisation JSON -----------------------------------------------------------------------
            
            //Personne p850 = new Personne("Safa","Ed");
            //Personne p851 = new Personne("Daridon","Willy");
            //List<Personne> lstpersonnes = new List<Personne>();
            //lstpersonnes.Add(p850);
            //lstpersonnes.Add(p851);

            //Stream fichier = File.Create("sav.json");
            //DataContractJsonSerializer serialiseur = new DataContractJsonSerializer(lstpersonnes.GetType());
            //serialiseur.WriteObject(fichier, lstpersonnes);
            //fichier.Close();

            //Stream fichierout = File.OpenRead("sav.json");
            //DataContractJsonSerializer serialKiller = new DataContractJsonSerializer(typeof(List<Personne>));
            //List<Personne> listerecup = (List<Personne>)serialKiller.ReadObject(fichierout);
            //foreach (var item in listerecup)
            //{
            //    Console.Out.WriteLine(item);
            //}

            //fichierout.Close();

            Console.ReadKey();
        }
    }
}
