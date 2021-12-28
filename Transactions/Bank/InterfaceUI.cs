using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public interface InterfaceUI
    {
        //Согласно принципу ISP, методы должны быть разделены, чтобы клиенты не зависели
        //от тех методов, которые они не используют

        public interface IRequests
        {
            double RequestDepositAmount();
            double RequestWithdrawalAmount();
            double RequestTransferAmount();
        }

        public interface IInformingService
        {
            void InformInsufficientFunds();
        }

        public interface IGiveOut
        {
            void GiveOutCash(double amount);
        }
    }
}
