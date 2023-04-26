using clinic.Model;
using clinic.Model.DataTransfer;
using clinic.Model.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MostPopularAnalysisController : ControllerBase
    {

        [HttpGet("{count}")]
        public async Task<IEnumerable<Analysistype?>> GetMostPopularAnalysis(int count)
        {
            return await AnalysisPurchasesCountHandler.GetMostPopularAnalysis(count);
        }
    }
}
