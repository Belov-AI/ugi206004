using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;

namespace Transactions
{
    public class PaymentTransaction
    {
        InterfaceUI ui;
        Account account;
        Service id;

        public PaymentTransaction(InterfaceUI ui, Account account, Service id, uint sum)
        {
            this.ui = ui;
            this.account = account;
            this.id = id;
        }

        public override void Execute()
        {
            uint sum;

            if (sum > account.Funds)
                ui.InformInsufficientFunds;
            else
            {
                account.Funds -= sum;
                id.Funds += sum;
            }

        }
    }
}
