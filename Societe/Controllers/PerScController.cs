using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Societe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;

namespace Societe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerScController : ControllerBase
    {
        private readonly DataContext dataContext;
        public PerScController(DataContext context)
        {
            this.dataContext = context;
        }


        //read
        [HttpGet]
        public async Task<JsonResult> Get()
        {


            return new JsonResult(await this.dataContext.PerSc.ToListAsync());

        }
        // creation
        [HttpPost]
        public async Task<JsonResult> Post(PerSc prs)
        {
            this.dataContext.PerSc.Add(prs);
            await this.dataContext.SaveChangesAsync();
            return new JsonResult("succès!");
        }
        //modifications update
        [HttpPut]

        public async Task<JsonResult> Put(PerSc prs)
        {

            var agentsc = await this.dataContext.PerSc.FindAsync(prs.Id);
            if (agentsc == null)
            {
                return new JsonResult("Societe non trouvé ");
            }
            agentsc.CarteID = agentsc.CarteID;
            agentsc.Nom_Prenom = agentsc.Nom_Prenom;

            await this.dataContext.SaveChangesAsync();

            return new JsonResult("actualisé");
        }


        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int Id)
        {


            var agentsc = await this.dataContext.PerSc.FindAsync(Id);
            if (agentsc == null)
            {
                return new JsonResult("Societe non trouvé");
            }

            dataContext.PerSc.Remove(agentsc);
            await this.dataContext.SaveChangesAsync();

            return new JsonResult(" Agent Supprimé !");
        }

    }
}
