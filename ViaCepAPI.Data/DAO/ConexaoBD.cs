using Npgsql;
using System.Data;

namespace ViaCepAPI.Data.DAO
{
    public class ConexaoBD
    {
        private NpgsqlConnection Connect;
        public ConexaoBD()
        {
            
        }
        public bool ConectaBanco()
        {
            string cnString = "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=viaCep;Pooling=true;";
            Connect = new NpgsqlConnection(cnString);
            Connect.Open();
            return true;
        }
        public DataSet ExecutaConsulta(string sSQL)
        {
            try
            {
                ConectaBanco();
                DataSet dataSet = new DataSet();
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter
                {
                    SelectCommand = new NpgsqlCommand(sSQL, Connect)
                };

                dataAdapter.SelectCommand.CommandTimeout = 0;
                dataAdapter.Fill(dataSet);



                return dataSet;



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connect.Close();
            }

        }
    }
}
