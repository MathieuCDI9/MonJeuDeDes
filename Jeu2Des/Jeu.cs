﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jeu2Des;

namespace Jeu2Des
{
    /// <summary>
    /// La classe Jeu2Des décrit un jeu de Dés très simple. 
    /// Le jeu comprend 2 dés et un classement pour enregistrer les scores des joueur
    /// Quand un joueur fait une partie : il indique son nom puis il lance les 2 dés 10 fois de suite
    /// A chaque lancer, si le total des dés est égal à 7 ==> le joueur marque 10 points à son score
    /// Une fois la partie terminée le nom du joeur et son score sont enregistrés dans le classement 
    /// </summary>   
     public class Jeu
    {
        /// <summary>
        ///     loloooooooo
        /// </summary>
              
        private Joueur _Joueur;
        
        private Classement _Classement ;

        //public Classement Classement
        //{
        //    get { return _Classement; }
        //    set { _Classement = value; }
        //}

        /// <summary>
        /// Représente le joueur courant (celui qui joue une partie)
        /// </summary>
        /// <returns>Le joueur de la partie ou null si aucune partie n'est démarrée</returns>        
        public Joueur Joueur
        {
            get{return _Joueur;}       
        }
    
        private De[] _Des = new De[2]; 

        
        /// <summary>
        /// Crée un jeu de 2 Dés avec un classement
        /// </summary> 
        public Jeu(int loader)
        {
            //A la création du jeu : les 2 dés sont crées 
            //On aurait pu créer les 2 Des juste au moment de jouer 
             
            _Des[0] = new De();
            _Des[1] = new De();            

            //int sauve = 1;

            switch (loader)
            {
                case 1:
                    _Classement = new ClassementBinaire();
                    break;

                case 2:
                    _Classement = new ClassementXML();
                    break;               

                default:
                    _Classement = new ClassementJSON();
                    break;
            }

            _Classement.Load();            
        }

        /// <summary>
        /// Permet de faire une partie du jeu de dés en indiquant le nom du joueur
        /// </summary>
        /// <param name="nom">Le nom du joueur</param>
        public int JouerPartie(string nom)
        {
            //Le joueur est créé quand la partie démarre
            _Joueur = new Joueur(nom);

            //On fait jouer le joueur en lui passant les 2 dés
            int resultat = _Joueur.Jouer(_Des);

            _Classement.AjouterEntree(nom, resultat);

            return resultat;
        }

        /// <summary>
        /// Permet de faire une partie du jeu de dés
        /// Le nom du joueur n'est pas donnée en entrée : il sera généré exemple : Joueur 1, Joueur 2, ...  
        /// </summary>        
        public int JouerPartie()
        {
            //Le joueur est créé quand la partie démarre
            _Joueur = new Joueur();            

            //Le joueur Joue et on récupère son score
            int resultat = _Joueur.Jouer(_Des);

            _Classement.AjouterEntree(_Joueur.Nom, resultat);

            return resultat;
        }

        public void VoirClassement()
        {
            _Classement.TopN();
        }

        public void VoirClassement(int n)
        {
            _Classement.TopN(n);
        }

        public void Quitter()
        {
            _Classement.Save();
        }        

    }
}
