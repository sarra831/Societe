using Societe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace Societe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocietesController : ControllerBase
    {
        //to read the connexin string from appsettings file we use dependancy injection 
        private readonly IConfiguration configuration;
        public SocietesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
    // api methode to get all data from societe table 
    [HttpGet]
    public JsonResult Get()
    {
        string query = @"select Id , Nom ,Responsable,MatriculeFiscal,Date from dbo.Societe";
        DataTable table = new DataTable();
        string sqlDataSource = this.configuration.GetConnectionString("SocieteAppCon");
        SqlDataReader myReader; 
        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myCon.Close();
            }
        }

        return new JsonResult(table);

    }
     














}




