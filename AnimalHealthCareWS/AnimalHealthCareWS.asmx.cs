using AnimalHealthCareWS.model;
using AnimalHealthCareWS.utils;
using System;
using System.Collections.Generic;
using NHibernate.Linq;
using System.Web;
using System.Web.Services;
using System.Linq;
using AnimalHealthCareWS.business;

namespace AnimalHealthCareWS
{
  
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class AnimalHealthCareWS : System.Web.Services.WebService
    {

        [WebMethod]
        public Message NewExam(string padrone_nome, string padrone_cognome, string taxid , string tipo_di_visita , string nome_animale, string tipoanimale)
        {



            Message esito=  AnimalHealhCareBSN.ExaminationInsert(padrone_nome, padrone_cognome, taxid, tipo_di_visita, nome_animale, tipoanimale);


            return esito;


        }



        [WebMethod]
        public Message PayTheBill(string taxid, float pay)
        {


            Message esito = AnimalHealhCareBSN.PayBill(taxid, pay);


            return esito;


        }
     //   [WebMethod]
     //   public List<Examtype> GetExamTypes()
     //   {
     //       return AnimalHealhCareBSN.GetListExamType();
     //   }
     //
     //
     //
     //   [WebMethod]
     //   public List<Animal> GetAnimalsByType(String type)
     //   {
     //       return AnimalHealhCareBSN.GetAnimalsByType(type);
     //   }
     //   [WebMethod]
     //   public List<Animal> GetAnimalsByOwner(string taxid)
     //   {
     //       return AnimalHealhCareBSN.GetAnimalsByOwner(taxid);
     //   }
     //   [WebMethod]
     //   public Owner GetOwnerByTaxid(string taxid)
     //   {
     //       return AnimalHealhCareBSN.GetOwnerByTaxid(taxid);
     //   }
     //
     //   [WebMethod]
     //   public List<Exam> GetExamListByAnimalID(int idanimal)
     //   {
     //       return AnimalHealhCareBSN.GetExamListByAnimalID(idanimal);
     //   }
    }
}
