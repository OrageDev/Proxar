using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Proxar.Modele
{
    class BDDUserManagement
    {

        private string rq_sql;                              //Objet string qui contiendra les requêtes SQL
        private string cnx;                                 //Object string qui contiendra la clé de connection a la BDD
        private SqlConnection oCNX;                         //Objet Connection de BDD
        private SqlCommand oCMD;                            //Objet Command qui executera une requête SQL
        private SqlDataAdapter oDA;                         //Objet DataAdapter qui fait le lien entre l'application et la BDD
        private System.Data.DataSet oDS;                    //Objet qui stock en local les informations de la BDD

        public BDDUserManagement()
        {
            this.rq_sql = null;
            //Changer l'emplacement ou ce trouve votre BDD.
            this.cnx = @"Data Source=db-proxar.database.windows.net;Initial Catalog=db_proxar;Persist Security Info=True;User ID=rootProxar;Password=@PR0xAR@";
            this.oCNX = new SqlConnection(this.cnx);
            this.oCMD = null;
            this.oDA = null;
            this.oDS = new DataSet();

        }



        public int SelectRequest()
        {

            this.oDS = new DataSet();
            this.rq_sql = "SELECT * FROM db_proxar;";                           //Requête SELECT Paramétrée
            this.oCMD = new SqlCommand(this.rq_sql, this.oCNX);                      //Création d'un objet commande qui prend en paramètre la requête SQL et la l'objet de Connexion a la BDD.
            this.oDA = new SqlDataAdapter(this.oCMD);                                //Création d'un objet DataAdapter qui prend en paramètre l'objet commande. (DataAdapter et l'interface réel entre l'application et la BDD.
            this.oDA.Fill(this.oDS, "Etudiant");                              //Mais bien définir la table a afficher, car le DataSet peut en contenir plusieur.
            int test = this.oDS.Tables.Count;
            return test;
        }
          
    }
}
