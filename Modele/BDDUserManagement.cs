using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Proxar.Modele
{
    class BDDUserManagement
    {

        private string rq_sql;                              //Objet string qui contiendra les requêtes SQL
        private string cnx;                                 //Object string qui contiendra la clé de connection a la BDD
        private System.Data.OleDb.OleDbConnection oCNX;     //Objet Connection de BDD
        private System.Data.OleDb.OleDbCommand oCMD;        //Objet Command qui executera une requête SQL
        private System.Data.OleDb.OleDbDataAdapter oDA;     //Objet DataAdapter qui fait le lien entre l'application et la BDD
        private System.Data.DataSet oDS;                    //Objet qui stock en local les informations de la BDD

        public BDDUserManagement()
        {
            this.cnx = @"Provider = db-proxar.database.windows.net";
            this.oCNX = new System.Data.OleDb.OleDbConnection(this.cnx);
            this.oCMD = null;
            this.oDA = null;
            this.oDS = new DataSet();

        }



        public void SelectRequest()
        {

            this.oDS = new DataSet();
            this.rq_sql = "SELECT * FROM TB_PERSONNE;";                              //Requête SELECT Paramétrée
            this.oCMD = new System.Data.OleDb.OleDbCommand(this.rq_sql, this.oCNX);  //Création d'un objet commande qui prend en paramètre la requête SQL et la l'objet de Connexion a la BDD.
            this.oDA = new System.Data.OleDb.OleDbDataAdapter(this.oCMD);            //Création d'un objet DataAdapter qui prend en paramètre l'objet commande. (DataAdapter et l'interface réel entre l'application et la BDD.
            this.oDA.Fill(this.oDS, "etudiant");

        }
          
    }
}
