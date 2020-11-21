namespace WebReportSolution.ViewModels.ExportReport
{
    public class ExpReportNumberOfOrdersByDate
    {
        public string Date { get; set; }

        public int AmountToOneThousand { get; set; }

        public int AmountToFiveThousand { get; set; }

        public int AmountFromFiveThousand { get; set; }
    }
}