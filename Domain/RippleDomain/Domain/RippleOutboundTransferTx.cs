﻿using DotPay.RippleDomain.Events;
using FC.Framework.Domain;
using FC.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotPay.Common;
using DotPay.RippleDomain.Exceptions;

namespace DotPay.RippleDomain
{
    public class RippleOutboundTransferTx : DomainBase, IAggregateRoot,
                                          IEventHandler<RippleOutboundTransferTxCreated>,
                                          IEventHandler<RippleOutboundTransferSigned>
    {
        #region ctor
        protected RippleOutboundTransferTx() { }

        public RippleOutboundTransferTx(string destination, int destinationTag, string targetCurrency, decimal targetAmount, decimal tourceSendMaxAmount, List<object> ripplePaths)
        {
            this.RaiseEvent(new RippleOutboundTransferTxCreated(destination, destinationTag, targetCurrency, targetAmount, tourceSendMaxAmount, ripplePaths));
        }

        #endregion

        public virtual int ID { get; protected set; }
        public string TxId { get; protected set; }
        public string Destination { get; protected set; }
        public int DestinationTag { get; protected set; }
        public TransactionState State { get; protected set; }
        public string TargetCurrency { get; protected set; }
        public string TxBlob { get; protected set; }
        public decimal TargetAmount { get; protected set; }
        public decimal SourceAmount { get; protected set; }
        public decimal Fee { get; protected set; }
        public decimal SourceSendMaxAmount { get; protected set; }

        public virtual void MarkSigned(string txid, string txblob)
        {
            if (this.State != TransactionState.Init)
                throw new RippleTransactionNotPendingException();
            else
                this.RaiseEvent(new RippleOutboundTransferSigned(this.ID, txid, txblob));
        } 

        public void Handle(RippleOutboundTransferTxCreated @event)
        {
            this.Destination = @event.Destination;
            this.DestinationTag = @event.DestinationTag;
            this.TargetCurrency = @event.TargetCurrency;
            this.TargetAmount = @event.TargetAmount;
            this.State = TransactionState.Init;
            this.SourceSendMaxAmount = @event.SourceSendMaxAmount;
        }

        public void Handle(RippleOutboundTransferSigned @event)
        {
            this.TxId = @event.Txhash;
            this.TxBlob = @event.Txblob;
        }
    }
}