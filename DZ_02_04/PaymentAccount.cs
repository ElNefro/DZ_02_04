using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public class PaymentAccount : ISerializable
    {
        public decimal DailyPayment { get; set; }
        public decimal NumberOfDays { get; set; }
        public decimal PenaltyPerDay { get; set; }
        public decimal DelayDays { get; set; }

        public decimal TotalWithoutPenalty => DailyPayment * NumberOfDays;
        public decimal Penalty => PenaltyPerDay * DelayDays;
        public decimal TotalWithPenalty => TotalWithoutPenalty + Penalty;

        public static bool SerializeComputedFields {  get; set; } = true;

        public PaymentAccount(decimal dailyPayment, int numberOfDays, decimal penaltyPerDay, int delayDays)
        {
            DeilyPayment = dailyPayment;
            NumberOfDays = numberOfDays;
            PenaltyPerDay = penaltyPerDay;
            DelayDays = delayDays;

        }
       

        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DailyPayment", DailyPayment);
            info.AddValue("NumberOfDays", NumberOfDays);
            info.AddValue("PenaltyPerDay", PenaltyPerDay);
            info.AddValue("DelayDays", DelayDays);

            if (SerializeComputedFields)
            {
            info.AddValue("TotalWithoutPenalty", TotalWithoutPenalty);
            info.AddValue("Penalty", Penalty);
            info.AddValue("TotalWithPenalty", TotalWithPenalty);
            }

        }
        public override string ToString()
        {
        return $"Daily Payment: (DailyPayment)\n" +
               $"Number Of Days: (NumberOfDays)\n" +
               $"Penalty Per Day: (PenaltyPerDay)\n" +
               $"Delay Days:(DelayDays)\n" +
               $"Total With Penalty: (TotalWithPenalty)\n" +
               $"Penalty: (Penalty)\n" +
               $"Total With Penalty: (TotalWithPenalty)\n";
        }
    }
}
