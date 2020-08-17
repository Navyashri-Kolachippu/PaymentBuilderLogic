using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaymentBuilderBusinessData;
using PaymentBuilderDataObjects;

namespace PaymentBuilder.Controllers
{
    public class PaymentsController : Controller
    {
        PaymentsData payments = new PaymentsData();
        //PaymentType data = new PaymentType();

        [HttpPost]
        public string PaymentCheck(PaymentType PaymentType)
        {
            string message = string.Empty;

            if (PaymentType.IsVideo == true)
            {
                if (PaymentType.LearningToSki == true)
                {
                    int flag = 2;
                    message = payments.GeneratePackagingSlip(flag);
                }

                else
                {
                    message = "PaymentType Not Valid";
                }

            }

            else if (PaymentType.NewMember == true && PaymentType.PaymentValue == "NewMembership"&& (string.IsNullOrEmpty(PaymentType.UserId)))
            {
                NewUser newmember = new NewUser();
                newmember = payments.ActivateMembership(PaymentType.UserName);
                if (newmember.message != "Error Occured")
                {
                    int flag = 1;
                    payments.MailUser(newmember.UserId, newmember.UserName, flag);
                    message = newmember.message;
                }
            }

            else
            {
                if (PaymentType.PaymentValue == "PhysicalProduct")
                {
                    int flag = 1;
                    message = payments.GeneratePackagingSlip(flag);
                    if (message != "Error Occured")
                    {
                        payments.GenerateComissionForAgent(PaymentType.AgentId);
                    }
                }
                else if (PaymentType.PaymentValue == "Book")
                {
                    message = payments.DuplicatePackagingSlipForRoyalty();
                    if (message != "Error Occured")
                    {
                        payments.GenerateComissionForAgent(PaymentType.AgentId);
                    }
                }

                else if (PaymentType.PaymentValue == "UpgradeMembership")
                {
                    message = payments.UpgradeMembership(PaymentType.UserId, PaymentType.UserName);
                    if (message != "Error Occured")
                    {
                        int flag = 2;
                        payments.MailUser(PaymentType.UserId, PaymentType.UserName, flag);
                    }
                }

                else
                {
                    message = "Payment Type is not valid";
                }
            }

            return message;
        }
    }
}