using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Societe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;

namespace PerSc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerScController : ControllerBase
    {
        private readonly DataContext DataContext;
        public PerScController(DataContext context)
        {
            this.DataContext = context;
        }


        //read
        [HttpGet]
        public async Task<JsonResult> Get()
        {


            return new JsonResult(await this.DataContext.PerSc.ToListAsync());

        }
        // creation
        [HttpPost]
        public async Task<JsonResult> Post(PerSc prs)
        {
            this.DataContext.PerSc.Add(prs);
            await this.DataContext.SaveChangesAsync();
            return new JsonResult("succès!");
        }
        //modifications update
        [HttpPut]

        public async Task<JsonResult> Put(PerSc prs)
        {

            var agentsc = await this.DataContext.PerSc.FindAsync(prs.Id);
            if (agentsc == null)
            {
                return new JsonResult("Societe non trouvé ");
            }
            agentsc.CarteID = agentsc.CarteID;
            agentsc.Nom_Prenom = agentsc.Nom_Prenom;

            await this.DataContext.SaveChangesAsync();

            return new JsonResult("actualisé");
        }


        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int Id)
        {


            var agentsc = await this.DataContext.PerSc.FindAsync(Id);
            if (agentsc == null)
            {
                return new JsonResult("Agent non trouvé");
            }

            DataContext.PerSc.Remove(agentsc);
            await this.DataContext.SaveChangesAsync();

            return new JsonResult(" Agent Supprimé !");
        }

    }
}
