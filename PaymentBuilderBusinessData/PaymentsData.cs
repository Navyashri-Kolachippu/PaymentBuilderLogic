﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentBuilderBusinessData
{
    public class PaymentsData
    {
        public string GeneratePackagingSlip(int flag)
        {
            string message = string.Empty;
            try
            {
                if (flag == 1)
                {
                    //logic for generation of slip
                    message = "Packaging slip for shipping Generated";
                }
                else if (flag == 2)
                {
                    //add free first aid video
                    message = "Packaging slip for shipping with free first aid video Generated";
                }
            }
            catch (Exception ex)
            {
                message = "Error Occured";
            }
            return message;
        }
        public string DuplicatePackagingSlipForRoyalty()
        {
            string message = string.Empty;
            try
            {
                //logic for royalty dept packaging slip
                message = "Duplicate PackagingSlip For Royalty Department is Generated";
            }
            catch (Exception ex)
            {
                message = "Error Occured";
            }
            return message;
        }
        public NewUser ActivateMembership(string UserName)
        {
            NewUser newmember = new NewUser();
            try
            {
                //add new member to database and generate new id and name

                newmember.UserId = "UserId1";//autogenerated
                newmember.message = "New Membership is activated";
                newmember.UserName = UserName;
            }

            catch (Exception ex)
            {
                newmember.UserId = string.Empty;
                newmember.message = "Error Occured";
                newmember.UserName = UserName;
            }
            return newmember;
        }

        public string UpgradeMembership(string UserId, string UserName)
        {
            string message = string.Empty;
            try
            {
                //upgrade new member in db
                message = "Membership is upgraded";
            }
            catch (Exception ex)
            {
                message = "Error Occured";
            }

            return message;
        }

        public void MailUser(string UserId, string UserName, int flag)
        {
            if (flag == 1)
            {
                //mail user for activation
            }
            else if (flag == 2)
            {
                //mail user for upgradation
            }
        }

        public void GenerateComissionForAgent(string agentId)
        {
            //logic for comission generation
        }
    }
}
