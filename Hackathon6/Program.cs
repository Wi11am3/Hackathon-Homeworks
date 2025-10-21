namespace Hackathon6
{
    internal class Program
    {       
            static void Main(string[] args)
            {
                Console.WriteLine("請輸入你的年收入");
                int income = int.Parse(Console.ReadLine());

                List<RateData> taxList = CreateRateData();

                var matchedLevel = (from x in taxList
                                    where income >= x.StartMoney && income <= x.EndMoney
                                    select x).FirstOrDefault();

                if (matchedLevel == null)
                {
                    Console.WriteLine("找不到對應級距");
                    return;
                }

                var extraTax = (from x in taxList
                                where x.EndMoney < matchedLevel.StartMoney
                                select x.Price).Sum();
            decimal currentTax;
            if (matchedLevel.StartMoney == 0)
            {
                currentTax = income * matchedLevel.Rate;//級距一直接用income計算
            }
            else
            {
                currentTax = (income - matchedLevel.StartMoney + 1) * matchedLevel.Rate;
            }                    
                var totalTax = extraTax + currentTax;
                Console.WriteLine(totalTax);
            }

            static List<RateData> CreateRateData()
            {
                return new List<RateData>
            {
                new RateData{Imcome="級距1" , StartMoney=0m ,        EndMoney=540000m ,          Rate=0.05m , Price=27000m},
                new RateData{Imcome="級距2" , StartMoney=540001m ,   EndMoney=1210000m ,         Rate=0.12m , Price=80400m},
                new RateData{Imcome="級距3" , StartMoney=1210001m ,  EndMoney=2420000m ,         Rate=0.20m , Price=242000m},
                new RateData{Imcome="級距4" , StartMoney=2420001m ,  EndMoney=4530000m ,         Rate=0.30m , Price=633000m},
                new RateData{Imcome="級距5" , StartMoney=4530001m ,  EndMoney=10310000 ,         Rate=0.40m , Price=2312000m},
                new RateData{Imcome="級距6" , StartMoney=10310001m , EndMoney=decimal.MaxValue , Rate=0.50m , Price=0m}
            };           
        }
    }
}
