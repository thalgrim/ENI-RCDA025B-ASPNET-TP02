using System;
using System.Collections.Generic;
using System.Linq;

namespace TP02Module03
{
    class Program
    {
        static void Main(string[] args)
        {
            InitialiserDatas();

            Console.WriteLine("Liste des prénoms des auteurs dont le nom commence par G");
            var auteurs = ListeAuteurs.Where(a => a.Nom.StartsWith("G"));
            foreach (var auteur in auteurs)
            {
                Console.WriteLine($"{auteur.Prenom}");
            }

            Console.WriteLine("\nAuteur ayant écrit le plus de livres");
            var auteurProlifique = ListeLivres.GroupBy(livre => livre.Auteur).OrderByDescending(comptage => comptage.Count()).FirstOrDefault();
            Console.WriteLine($"{auteurProlifique.Key.Nom} {auteurProlifique.Key.Prenom}");

            Console.WriteLine("\nNombre moyen de pages par livre par auteur");
            var auteurPage = ListeLivres.GroupBy(livre => livre.Auteur);
            foreach (var auteur in auteurPage)
            {
                Console.WriteLine($"{auteur.Key.Prenom} {auteur.Key.Nom} : {auteur.Average(n=>n.NbPages)}");
            }

            Console.WriteLine("\nTitre du livre avec le plus de pages");
            var titre = ListeLivres.OrderByDescending(nbrePage => nbrePage.NbPages).FirstOrDefault();
            Console.WriteLine($"{titre.Titre}");

            Console.WriteLine("\nCombien ont gagné les auteurs en moyenne");
            var salaire = ListeAuteurs.Average(moyenne => moyenne.Factures.Sum(facture=>facture.Montant));
            Console.WriteLine($"{salaire}");

            Console.WriteLine("\nles auteurs et la liste de leurs livres");
            var livres = ListeLivres.GroupBy(livre => livre.Auteur);
            foreach (var livre in livres)
            {
                Console.WriteLine($"{livre.Key.Nom} {livre.Key.Prenom} ");
                foreach (var livre2 in livre)
                {
                    Console.WriteLine($"{livre2.Titre}");
                }
            }

            Console.WriteLine("\nLes titres de tous les livres triés par ordre alphabétique");
            var listeLivresParTitre = ListeLivres.OrderBy(titre => titre.Titre);
            foreach (var livre in listeLivresParTitre)
            {
                Console.WriteLine($"{livre.Titre}");
            }

            Console.WriteLine("\nListe des livres dont le nombre de pages est supérieur à la moyenne");
            var moyenneNbrePages = ListeLivres.Average(nbrePages => nbrePages.NbPages);
            var listelivresNbrePagesSupMoyenne = ListeLivres.Where(livre => livre.NbPages > moyenneNbrePages);
            foreach (var livre in listelivresNbrePagesSupMoyenne)
            {
                Console.WriteLine($"{livre.Titre}");
            }

            Console.WriteLine("\nAuteur ayant écrit le moins de livres");
            var auteurMoinsProlifique = ListeLivres.GroupBy(livre => livre.Auteur).OrderBy(comptage => comptage.Count()).FirstOrDefault();
            Console.WriteLine($"{auteurMoinsProlifique.Key.Nom} {auteurMoinsProlifique.Key.Prenom}");
            
            Console.ReadKey();
        }

        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
    }
}

