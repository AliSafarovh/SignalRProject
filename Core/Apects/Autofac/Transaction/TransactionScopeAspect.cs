﻿using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Apects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed(); // Metodu işlət
                    transactionScope.Complete(); // Metod uğurludur davam et (Cathce düşmür)
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose(); // Metod uğursuzdur hər şeyi geri qaytar (Rollback)
                    throw;
                }
            }
        }
    }
}
