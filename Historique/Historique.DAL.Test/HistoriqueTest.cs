using System;
using System.Collections.Generic;
using System.Linq;
using Historique.DAL.DAL;
using Historique.DAL.DAO;
using Historique.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Historique.DAL.Test
{
    [TestClass]
    public class HistoriqueTest
    {
        private const int MOCK_LISTS_SIZE = 3;

        private Mock<IHistorique> _historiqueMock;

        private UtilisateurDao _exceptedUser;
        private EvenementDao _expectedEvent;
        private List<UtilisateurDao> _expectedUsers;
        private List<EvenementDao> _expectedEvents;
        private List<CategorieDao> _expectedCategories;

        [TestInitialize]
        public void Initialize()
        {
            this._historiqueMock = new Mock<IHistorique>();

            InitializeExpectedUtilisateurDao();
            InitializeExpectedEvenementDao();

            InitializeExpectedUtilisateurDaos();
            InitializeExpectedEvenementDaos();
            InitializeExpectedCategorieDaos();
        }

        private void InitializeExpectedUtilisateurDaos()
        {
            this._expectedUsers = new List<UtilisateurDao>();

            for (var i = 0; i < MOCK_LISTS_SIZE; i++)
            {
                this._expectedUsers.Add(new UtilisateurDao());
            }
        }

        private void InitializeExpectedEvenementDaos()
        {
            this._expectedEvents = new List<EvenementDao>();

            for (var i = 0; i < MOCK_LISTS_SIZE; i++)
            {
                this._expectedEvents.Add(new EvenementDao());
            }
        }

        private void InitializeExpectedCategorieDaos()
        {
            this._expectedCategories = new List<CategorieDao>();

            for (var i = 0; i < MOCK_LISTS_SIZE; i++)
            {
                this._expectedCategories.Add(new CategorieDao());
            }
        }

        private void InitializeExpectedUtilisateurDao()
        {
            this._exceptedUser = new UtilisateurDao()
            {
                Id = 2,
                Age = 20,
                Pseudo = "TestUser",
                Metier = "DEV",
                Ville = "Bordeaux"
            };
        }

        private void InitializeExpectedEvenementDao()
        {
            this._expectedEvent = new EvenementDao()
            {
                Id = 1,
                Etat = "CREATED",
                Description = "Test event",
                Statut = "CREATED",
                Titre = "TestEvent",
                IdUser = 2,
                DateEvenement = new DateTime(2014, 11, 1),
                DateFinIncription = new DateTime(2014, 11, 7)
            };

            this._expectedEvent.Participants = new List<UtilisateurDao>()
            {
                this._exceptedUser
            };

            this._expectedEvent.Lieu = new EvenementLieuDao()
            {
                Id = 1,
                CodePostale = "33000",
                Pays = "France",
                Ville = "Bordeaux",
                Latitute = 1,
                Longitude = 1
            };

            this._expectedEvent.Categorie = new CategorieDao()
            {
                Id = 1,
                Libelle = "TestCategory"
            };
        }

        [TestMethod]
        public void TestGetAllCategorie()
        {
            this._historiqueMock.Setup(m => m.GetAllCategorie())
                .Returns(_expectedCategories);

            var categories = this._historiqueMock.Object.GetAllCategorie();

            Assert.IsNotNull(categories);
            Assert.AreEqual(categories.ToList().Count, _expectedCategories.Count);
        }

        [TestMethod]
        public void TestGetAllUser()
        {
            this._historiqueMock.Setup(m => m.GetAllUser())
                .Returns(_expectedUsers);

            var users = this._historiqueMock.Object.GetAllUser();

            Assert.IsNotNull(users);
            Assert.AreEqual(users.ToList().Count, _expectedUsers.Count);
        }

        [TestMethod]
        public void TestGetUserById()
        {
            this._historiqueMock.Setup(m => m.GetUserById(_exceptedUser.Id))
                .Returns(_exceptedUser);

            var userById = this._historiqueMock.Object.GetUserById(_exceptedUser.Id);

            Assert.IsNotNull(userById);
            Assert.AreEqual(userById.Id, _exceptedUser.Id);
            Assert.AreEqual(userById.Age, _exceptedUser.Age);
            Assert.AreEqual(userById.Metier, _exceptedUser.Metier);
            Assert.AreEqual(userById.Ville, _exceptedUser.Ville);
        }

        [TestMethod]
        [ExpectedException(typeof(HistoricEntityNotFoundException))]
        public void TestGetUserByIdNotFound()
        {
            const int unknownUserId = 10005;

            this._historiqueMock.Setup(m => m.GetUserById(unknownUserId))
                .Throws(new HistoricEntityNotFoundException("Utilisateur", "id", unknownUserId.ToString()));

            UtilisateurDao utilisateurDaoNotFound = this._historiqueMock.Object.GetUserById(unknownUserId);
        }

        [TestMethod]
        public void TestGetUserByPseudo()
        {
            this._historiqueMock.Setup(m => m.GetUserByPseudo(_exceptedUser.Pseudo))
                .Returns(_exceptedUser);

            var userByPseudo = this._historiqueMock.Object.GetUserByPseudo(_exceptedUser.Pseudo);

            Assert.IsNotNull(userByPseudo);
            Assert.AreEqual(userByPseudo.Pseudo, _exceptedUser.Pseudo);
        }

        [TestMethod]
        public void TestGetAllEvenement()
        {
            this._historiqueMock.Setup(m => m.GetAllEvenement())
                .Returns(_expectedEvents);

            var events = this._historiqueMock.Object.GetAllEvenement();

            Assert.IsNotNull(events);
            Assert.AreEqual(events.ToList().Count, _expectedEvents.Count);
        }

        [TestMethod]
        public void TestGetEvenementByCateByCp()
        {
            var zipCode = Int32.Parse(_expectedEvent.Lieu.CodePostale);

            this._historiqueMock.Setup(
                m =>
                    m.GetEvenementByCateByCp(zipCode,
                        _expectedEvent.Categorie.Libelle))
                .Returns(new List<EvenementDao>() {_expectedEvent});

            var eventsByCateByCpDao =
                this._historiqueMock.Object.GetEvenementByCateByCp(Int32.Parse(_expectedEvent.Lieu.CodePostale),
                    _expectedEvent.Categorie.Libelle);

            Assert.IsNotNull(eventsByCateByCpDao);
            Assert.AreEqual(eventsByCateByCpDao.ToList().Count, 1);
        }

        [TestMethod]
        public void TestGetEvenementByCp()
        {
            var zipCode = Int32.Parse(_expectedEvent.Lieu.CodePostale);

            this._historiqueMock.Setup(m => m.GetEvenementByCp(zipCode))
                .Returns(new List<EvenementDao>() {_expectedEvent});

            var eventsByCp = this._historiqueMock.Object.GetEvenementByCp(zipCode);

            Assert.IsNotNull(eventsByCp);
            Assert.AreEqual(eventsByCp.ToList().Count, 1);
        }

        [TestMethod]
        public void GetEvenementByCat()
        {
            var eventStartDate = new DateTime(2014, 11, 1);
            var eventEndDate = new DateTime(2014, 11, 7);

            var category = _expectedEvent.Categorie.Libelle;

            this._historiqueMock.Setup(m => m.GetEvenementByCat(category, eventStartDate, eventEndDate))
                .Returns(new List<EvenementDao>() {_expectedEvent});

            var eventsByCatAndDates = this._historiqueMock.Object.GetEvenementByCat(category, eventStartDate,
                eventEndDate);

            Assert.IsNotNull(eventsByCatAndDates);
            Assert.AreEqual(eventsByCatAndDates.ToList().Count, 1);
        }

        [TestMethod]
        public void TestGetEvenementByDates()
        {
            var eventStartDate = new DateTime(2014, 11, 1);
            var eventEndDate = new DateTime(2014, 11, 7);

            this._historiqueMock.Setup(m => m.GetEvenementByDates(eventStartDate, eventEndDate))
                .Returns(new List<EvenementDao>() {_expectedEvent});

            var eventsByDates = this._historiqueMock.Object.GetEvenementByDates(eventStartDate, eventEndDate);

            Assert.IsNotNull(eventsByDates);
            Assert.AreEqual(eventsByDates.ToList().Count, 1);
        }

        [TestMethod]
        public void TestGetEvenementParticipeByUserId()
        {
            var userId = _exceptedUser.Id;

            this._historiqueMock.Setup(m => m.GetEvenementParticipeByUserId(userId))
                .Returns(new List<EvenementDao>() {_expectedEvent});

            var eventsByUserId = this._historiqueMock.Object.GetEvenementParticipeByUserId(userId);

            Assert.IsNotNull(eventsByUserId);
            Assert.AreEqual(eventsByUserId.ToList().Count, 1);
        }

        [TestMethod]
        public void TestGetUtilisateurParticipeByEvenementId()
        {
            var eventId = _expectedEvent.IdUser;

            this._historiqueMock.Setup(m => m.GetUtilisateurParticipeByEvenementId(eventId))
                .Returns(new List<UtilisateurDao>() {_exceptedUser});

            var eventsParticipantsByEventId = this._historiqueMock.Object.GetUtilisateurParticipeByEvenementId(eventId);

            Assert.IsNotNull(eventsParticipantsByEventId);
            Assert.AreEqual(eventsParticipantsByEventId.ToList().Count, 1);
        }

        [TestMethod]
        public void TestGetEvenementProposeByUserId()
        {
            this._historiqueMock.Setup(m => m.GetEvenementProposeByUserId(_exceptedUser.Id))
                .Returns(new List<EvenementDao>() {_expectedEvent});

            var eventsByUserId = this._historiqueMock.Object.GetEvenementProposeByUserId(_exceptedUser.Id);

            Assert.IsNotNull(eventsByUserId);
            Assert.AreEqual(eventsByUserId.ToList().Count, 1);
        }

        [TestMethod]
        public void TestGetUtilisateurProposeByEvenementId()
        {
            this._historiqueMock.Setup(m => m.GetUtilisateurProposeByEvenementId(_expectedEvent.Id))
                .Returns(_exceptedUser);

            var utilisateurProposeByEvenementId = this._historiqueMock.Object.GetUtilisateurProposeByEvenementId(_expectedEvent.Id);

            Assert.IsNotNull(utilisateurProposeByEvenementId);
        }
    }
}
