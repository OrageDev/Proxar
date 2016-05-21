using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Proxar.Modele
{
    class BDDUserManagement
    {

        //private string rq_sql;                              //Objet string qui contiendra les requêtes SQL
        private string cnx;                                 //Object string qui contiendra la clé de connection a la BDD
        //private SqlConnection oCNX;                         //Objet Connection de BDD
        //private SqlCommand oCMD;                            //Objet Command qui executera une requête SQL
        //private SqlDataAdapter oDA;                         //Objet DataAdapter qui fait le lien entre l'application et la BDD
        //private System.Data.DataSet oDS;                    //Objet qui stock en local les informations de la BDD

        public BDDUserManagement()
        {
            //this.rq_sql = null;
            //Changer l'emplacement ou ce trouve votre BDD.
            this.cnx = @"Data Source=db-proxar.database.windows.net;Initial Catalog=db_proxar;Persist Security Info=True;User ID=rootProxar;Password=@PR0xAR@";
            //this.oCNX = new SqlConnection(this.cnx);
            //this.oCMD = null;
            //this.oDA = null;
            //this.oDS = new DataSet();

        }



        public void Connection()
        {
            
            SqlConnection cnn;
            cnn = new SqlConnection(this.cnx);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }
          
    }
}
