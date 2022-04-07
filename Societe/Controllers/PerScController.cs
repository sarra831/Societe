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

        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public PerScController(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }


    }
}
