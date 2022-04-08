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

        [HttpPost]
        public async Task<JsonResult> Post(Societes soc)
        {
            this.dataContext.Societes.Add(soc);
            await this.dataContext.SaveChangesAsync();
            return new JsonResult("succès!");
        }
      
        [HttpPut]

        public async Task<JsonResult> Put(Societes soc)
        {

            var societe = await this.dataContext.Societes.FindAsync(soc.Id);
            if (societe == null)
            {
                return new JsonResult("Societe non trouvé ");
            }
            societe.Nom = soc.Nom;
            societe.Responsable = soc.Responsable;
          
            await this.dataContext.SaveChangesAsync();

            return new JsonResult("actualisé");
        }

       
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int Id)
        {
            

            var societe = await this.dataContext.Societes.FindAsync(Id);
            if (societe == null)
            {
                return new JsonResult("Societe non trouvé");
            }

            dataContext.Societes.Remove(societe);
            await this.dataContext.SaveChangesAsync();

            return new JsonResult("Supprimé");
        }








    }
}




