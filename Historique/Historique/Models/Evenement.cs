﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Historique.Models
{
    public class Evenement
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _IdUser;

        public int IdUser
        {
            get { return _IdUser; }
            set { _IdUser = value; }
        }

        private DateTime _DateEvenement;

        public DateTime DateEvenement
        {
            get { return _DateEvenement; }
            set { _DateEvenement = value; }
        }

        private DateTime _DateModification;

        public DateTime DateModification
        {
            get { return _DateModification; }
            set { _DateModification = value; }
        }

        private DateTime _DateFinIncription;

        public DateTime DateFinIncription
        {
            get { return _DateFinIncription; }
            set { _DateFinIncription = value; }
        }

        private string _Titre;

        public string Titre
        {
            get { return _Titre; }
            set { _Titre = value; }
        }

        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private int _NbMaxParticipant;

        public int NbMaxParticipant
        {
            get { return _NbMaxParticipant; }
            set { _NbMaxParticipant = value; }
        }

        private int _NbMinParticipant;

        public int NbMinParticipant
        {
            get { return _NbMinParticipant; }
            set { _NbMinParticipant = value; }
        }

        private double _Prix;

        public double Prix
        {
            get { return _Prix; }
            set { _Prix = value; }
        }

        private bool _Premium;

        public bool Premium
        {
            get { return _Premium; }
            set { _Premium = value; }
        }

        private string _Etat;

        public string Etat
        {
            get { return _Etat; }
            set { _Etat = value; }
        }

        private string _Statut;

        public string Statut
        {
            get { return _Statut; }
            set { _Statut = value; }
        }

        private Categorie _Categorie;

        public Categorie Categorie
        {
            get
            {
                if (_Categorie == null)
                    _Categorie = new Categorie();
                return _Categorie;
            }
            set { _Categorie = value; }
        }

        private EvenementLieu _Lieu;

        public EvenementLieu Lieu
        {
            get
            {
                if (_Lieu == null)
                    _Lieu = new EvenementLieu();
                return _Lieu;
            }
            set
            {
                _Lieu = value;
            }
        }

        private List<Utilisateur> _Participants;
        public List<Utilisateur> Participants
        {
            get
            {
                if (_Participants == null)
                    _Participants = new List<Utilisateur>();
                return _Participants;
            }
            set
            {
                _Participants = value;
            }
        }
        private Utilisateur _Createur;
        public Utilisateur Createur
        {
            get
            {
                if (_Createur == null)
                    _Createur = new Utilisateur();
                return _Createur;
            }
            set
            {
                _Createur = value;
            }
        }
    }
}