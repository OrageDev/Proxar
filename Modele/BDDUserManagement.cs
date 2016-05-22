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

        private string rq_sql;                              //Objet string qui contiendra les requêtes SQL
        private string cnx;                                 //Object string qui contiendra la clé de connection a la BDD
        private SqlConnection sCNX;                         //Objet Connection de BDD
        private SqlCommand sCMD;                            //Objet Command qui executera une requête SQL
        private SqlDataReader sDR;                         //Objet DataReader qui fait le lien entre l'application et la BDD
        private bool isValidated;
        private string name;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        //private System.Data.DataSet oDS;                    //Objet qui stock en local les informations de la BDD

        public BDDUserManagement()
        {
            this.rq_sql = null;
            this.sCNX = null;  
            this.sCMD = null;
            this.cnx = @"Data Source=db-proxar.database.windows.net;Initial Catalog=db_proxar;Persist Security Info=True;User ID=rootProxar;Password=@PR0xAR@";
            this.sDR = null;
            this.isValidated = false;
            this.name = "";

            //this.oCMD = null;
            //this.oDA = null;
            //this.oDS = new DataSet();

        }

        public bool Connection()
        {
            this.sCNX = new SqlConnection(this.cnx);
            try
            {
                this.sCNX.Open();
                this.sCNX.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool SelectStudent(string id, string pass)
        {
            this.isValidated = false;
            this.rq_sql= "Select * FROM Etudiant;";
            this.sCNX = new SqlConnection(this.cnx);
            try
            {
                this.sCNX.Open();
                this.sCMD = new SqlCommand(this.rq_sql, this.sCNX);
                this.sDR = this.sCMD.ExecuteReader();
                if (this.sDR.FieldCount != 0)
                {
                    while (this.sDR.Read())
                    {
                        if(this.sDR.GetValue(4).ToString().Equals(id) && this.sDR.GetValue(5).ToString().Equals(pass))
                        {
                            this.name = this.sDR.GetValue(1).ToString() + " " +this.sDR.GetValue(2).ToString();
                            this.isValidated = true;
                        }
                    }
                    if(this.isValidated == false)
                    {
                        
                    }
                    
                    this.sDR.Close();
                    this.sCMD.Dispose();
                    this.sCNX.Close();
                }
                else
                {
                    
                        this.sDR.Close();
                        this.sCMD.Dispose();
                        this.sCNX.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La connection a la Database a échoué");
            }
            return this.isValidated;
        }
          
    }
}
