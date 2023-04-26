using clinic.Model;
using clinic.Model.Tables;
using Microsoft.EntityFrameworkCore;

namespace clinic.Model.DataTransfer
{
    public class AnalysisPurchasesCountHandler
    {
        public static async Task<List<Analysistype?>> GetMostPopularAnalysis(int count)
        {
            var context = new MedicalClinicContext();
            var mostPopularityAnalysis = (await context.Analysispopularuties.ToListAsync()).Take(new Range(0, count));
            List<Analysistype?> result = new List<Analysistype?>();
            foreach (var analysis in mostPopularityAnalysis)
            {
                result.Add(context.Analysistypes.Find(analysis.Analysisname));
            }
            return result;
        }

        public static void PostRandomPurchasesCount()
        {
            var random = new Random();
            var context = new MedicalClinicContext();
            for (int i = 1; i < context.Analysistypes.Count(); i++)
            {
                var entity = new Analysispopularuty
                {
                    Analysispopularityid = i,
                    Analysisname = i,
                    Purchasescount = random.Next(100, 1000),
                };
                context.Analysispopularuties.Add(entity);
            }
            context.SaveChanges();
        }

        public static void SortCompleteList()
        {
            var context = new MedicalClinicContext();
            var newOrder = context.Analysispopularuties.OrderByDescending(t => t.Purchasescount).ToList();
            context.Analysispopularuties.RemoveRange(context.Analysispopularuties.ToArray());
            context.SaveChanges();
            AddRange(newOrder);
        }

        public static void AddRange(List<Analysispopularuty> newOrder)
        {
            var context = new MedicalClinicContext();
            context.Analysispopularuties.AddRange(newOrder);
            context.SaveChanges();
        }

        private static void SortPartialList()
        {
            var context = new MedicalClinicContext();

        }
    }
}
