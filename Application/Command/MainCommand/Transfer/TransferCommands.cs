﻿using FC.Framework;
using FC.Framework.Utilities;
using DotPay.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotPay.Command
{
    public class CreateInsideTransfer : FC.Framework.Command
    {
        public CreateInsideTransfer(int fromUserID, int toUserID, CurrencyType currency, decimal amount, string description)
        {
            Check.Argument.IsNotNegativeOrZero(fromUserID, "fromUserID");
            Check.Argument.IsNotNegativeOrZero(toUserID, "toUserID");
            Check.Argument.IsNotNegativeOrZero((int)currency, "currency");

            this.FromUserID = fromUserID;
            this.ToUserID = toUserID;
            this.Currency = currency;
            this.Amount = amount;
            this.Description = description;
        }

        public int FromUserID { get; private set; }
        public int ToUserID { get; private set; }
        public CurrencyType Currency { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        /// <summary>
        /// 订单的sequence no
        /// </summary>
        public string Result { get; set; }
    }

    //public class ConfirmInsideTransfer : FC.Framework.Command
    //{
    //    public ConfirmInsideTransfer(string insideTransferSeq, CurrencyType currency)
    //    {
    //        Check.Argument.IsNotEmpty(insideTransferSeq, "insideTransferSeq");
    //        Check.Argument.IsNotNegativeOrZero((int)currency, "currency");

    //        this.InsideTransferSeq = insideTransferSeq;
    //        this.Currency = currency;
    //    }

    //    public string InsideTransferSeq { get; private set; }
    //    public CurrencyType Currency { get; private set; }
    //}


    public class SubmitInsideTransfer : FC.Framework.Command
    {
        public SubmitInsideTransfer(string insideTransferSeq, string tradePassword, CurrencyType currency)
        {
            Check.Argument.IsNotEmpty(insideTransferSeq, "insideTransferSeq");
            Check.Argument.IsNotEmpty(tradePassword, "tradePassword");
            Check.Argument.IsNotNegativeOrZero((int)currency, "currency");

            this.InsideTransferSeq = insideTransferSeq;
            this.TradePassword = tradePassword;
            this.Currency = currency;
        }

        public string InsideTransferSeq { get; private set; }
        public string TradePassword { get; private set; }
        public CurrencyType Currency { get; private set; }
    }


    public class OutsideTransfer : FC.Framework.Command
    {
        public OutsideTransfer(int userID, CurrencyType currency)
        {
            Check.Argument.IsNotNegativeOrZero(userID, "userID");
            Check.Argument.IsNotNegativeOrZero((int)currency, "currency");

            this.UserID = userID;
            this.Currency = currency;
        }

        public int UserID { get; private set; }
        public CurrencyType Currency { get; private set; }
    }

    public class ExchangeTransfer : FC.Framework.Command
    {
        public ExchangeTransfer(int userID, CurrencyType currency)
        {
            Check.Argument.IsNotNegativeOrZero(userID, "userID");
            Check.Argument.IsNotNegativeOrZero((int)currency, "currency");

            this.UserID = userID;
            this.Currency = currency;
        }

        public int UserID { get; private set; }
        public CurrencyType Currency { get; private set; }
    }
}
