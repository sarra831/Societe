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
        private readonly DataContext dataContext;
        public SocietesController(DataContext context)
        {
            this.dataContext = context;
        }
    


    [HttpGet]
    public async Task<JsonResult> Get()
    {
      

        return new JsonResult(await this.dataContext.Societes.ToListAsync());

    }


















}




