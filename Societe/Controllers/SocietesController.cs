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
        protected readonly IConfiguration configuration;
        public SocietesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }


    [HttpGet]
    public async Task<JsonResult> Get()
    {
      

        return new JsonResult(await this.dataContext.Societes.ToListAsync());

    }


















}




