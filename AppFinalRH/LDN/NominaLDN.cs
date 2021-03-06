﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using LAD;
using ODN;


namespace LDN
{
    public class NominaLDN
    {
        private NominaLAD objLAD;


        public NominaLDN()
        {
            objLAD = new NominaLAD();
        }

        public IEnumerable<Nomina> GetAll()
        {
            return objLAD.GetAll();
        }

        public IEnumerable<Nomina> GetApproved()
        {
            return objLAD.GetAll().Where(x => x.Estatus == "A");
        }

        public IEnumerable<Nomina> GetDenied()
        {
            return objLAD.GetAll().Where(x => x.Estatus == "R");
        }

        public IEnumerable<Nomina> GetPending()
        {
            return objLAD.GetAll().Where(x => x.Estatus == "P");
        }

        public Nomina GetById(int id)
        {
            return objLAD.GetById(id);
        }

        public void Insert(Nomina Nomina)
        {
            objLAD.Insert(Nomina);
        }

        public void Update(Nomina Nomina)
        {
            objLAD.Update(Nomina);
        }

        public void Delete(int id)
        {
            objLAD.Delete(id);
        }

        public void  ApproveOrRejectAll(List<int> Ids, string estatus)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    foreach (var x in Ids)
                    {
                        var a = objLAD.GetById(x);
                        a.Estatus = estatus;
                        objLAD.Update(a);
                    }

                    trans.Complete();
                }
                catch
                {
                    throw new Exception();
                }
            }
        }
    }
}
