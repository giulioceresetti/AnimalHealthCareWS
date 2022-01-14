using AnimalHealthCareWS.exceptions;
using AnimalHealthCareWS.model;
using AnimalHealthCareWS.utils;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalHealthCareWS.business
{
    public class AnimalHealhCareBSN
    {


        private static Owner GetOwner(ISession session, string ownerName, string ownerSurname , string taxid )
        {
            Owner owner = null;
            try
            {
                owner = session.Query<Owner>().Where(x => x.Taxid.ToUpper() == taxid.ToUpper()).First();
            }
            catch
            {

                owner = new Owner
                {
                    Name = ownerName,
                    Surname = ownerSurname,
                    Taxid = taxid.ToUpper(),
                    Unpayed = 0,
                    Balance = 0,
                    Payed = 0

                };
                session.Save(owner);

            }

            return owner;
        }

        private static Examtype GetExamType(ISession session, string examDesc)
        {
            return session.Query<Examtype>().Where(x => x.Description.ToUpper() == examDesc).First();
        }

        private static Animal GetAnimal(ISession session, string animalName, Owner owner, string animaltype)
        {
            Animal animal = null;
            try
            {
                animal = session.Query<Animal>().Where(x => x.Name.ToUpper() == animalName.ToUpper() && x.Owner == owner && x.Animaltype.ToUpper() == animaltype.ToUpper()).First();

            }
            catch
            {
                animal = new Animal { Name = animalName, Owner = owner, Animaltype = animaltype };

                session.Save(animal);
            }

            return animal;
        }

 //     public static List<Animal> GetAnimalsByType(string type)
 //     {
 //         using (var session = NHibernateHelper.GetCurrentSession())
 //         {
 //             List<Animal> listType = null;
 //             try
 //             {
 //                 listType = session.Query<Animal>().Where(x => x.Animaltype.ToUpper() == type.ToUpper()).ToList();
 //             }
 //             catch
 //             {
 //             }
 //             session.Close();
 //             return listType;
 //         }
 //     }
 //
 //
 //     public static List<Animal> GetAnimalsByOwner(string taxid)
 //     {
 //         using (var session = NHibernateHelper.GetCurrentSession())
 //         {
 //             List<Animal> listAnimals = null;
 //             try
 //             {
 //                 listAnimals = session.Query<Animal>().Where(x => x.Owner.Taxid == taxid.ToUpper()).ToList();
 //             }
 //             catch
 //             {
 //             }
 //             session.Close();
 //             return listAnimals;
 //         }
 //     }
 //     public static Owner GetOwnerByTaxid(string taxid)
 //     {
 //         using (var session = NHibernateHelper.GetCurrentSession())
 //         {
 //             Owner owner = null;
 //             try
 //             {
 //                 owner = session.Query<Owner>().Where(x => x.Taxid == taxid.ToUpper()).First();
 //             }
 //             catch
 //             {
 //             }
 //             session.Close();
 //             return owner;
 //         }
 //     }
 //
 //     public static List<Exam> GetExamListByAnimalID (int idAnimal)
 //     {
 //         using (var session = NHibernateHelper.GetCurrentSession())
 //         {
 //             List<Exam> exams = null;
 //             try
 //             {
 //                 exams = session.Query<Exam>().Where(x => x.Animal.Idanimal == idAnimal ).ToList();
 //             }
 //             catch
 //             {
 //             }
 //             session.Close();
 //             return exams;
 //         }
 //     }


        private static Exam InsertExam(ISession session, Animal animal, Examtype examType, String note)
        {
            Exam exam = new Exam
            {
                ExamDate = DateTime.Now,
                Animal = animal,
                Note = note,
                ExamType = examType
            };
            session.Save(exam);

            return exam;
        }


        public static List<Examtype> GetListExamType()
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                List<Examtype> listType = session.Query<Examtype>().ToList();
                 
                session.Close();
                return listType;
            }



        }


        public static Message PayBill(string taxid, float payment)
        {
            Message msg= null;

            Owner owner = null;
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    try
                    {
                        try
                        {
                            owner = session.Query<Owner>().Where(x => x.Taxid == taxid.ToUpper()).First();
                        } catch 
                        {
                            throw new OwnerNotFoundException();
                        }
                        if (payment < 0 || (0-payment) > owner.Balance)
                        {
                            throw new PaymentException();
                        }
                        else
                        {
                            owner.Payed += payment;
                            owner.Balance += payment;

                            session.Save(owner);

                        }
                        msg = new Message
                        {
                            Errorcode = Constants.ERROR_CODE_00,
                            ErrorMessage = Constants.ERROR_MSG_00
                        };
                        trans.Commit();
                    }
                    catch (PaymentException)
                    {
                        trans.Rollback();
                        msg = new Message
                        {
                            Errorcode = Constants.ERROR_CODE_77,
                            ErrorMessage = Constants.ERROR_MSG_77
                        };
                    }
                    catch (OwnerNotFoundException)
                    {
                        trans.Rollback();
                        msg = new Message
                        {
                            Errorcode = Constants.ERROR_CODE_45,
                            ErrorMessage = Constants.ERROR_MSG_45
                        };
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                         msg = new Message
                        {
                            Errorcode        = Constants.ERROR_CODE_99,
                            ErrorMessage = Constants.ERROR_MSG_99
                        };
                    }

                }
                session.Close();
            }
            return msg;



        }



        public static Message ExaminationInsert(string ownerName, string ownerSurname, string taxid,  string examDesc, string animalName, string animalType)
        {
            Message msg = null;


            using (var session = NHibernateHelper.GetCurrentSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    try
                    {
                        if(taxid.Length!=  16)
                        {
                            throw new OwnerNotFoundException();
                        }

                        Owner owner = GetOwner(session, ownerName, ownerSurname, taxid);

                        Animal animal = GetAnimal(session, animalName, owner, animalType);

                        Examtype examType = GetExamType(session, examDesc);

                        Exam exam = InsertExam(session, animal, examType, null);


                        if (owner.Balance >= 0)
                        {
                            owner.Unpayed += examType.Expense;
                            owner.Balance -= examType.Expense;
                            session.Save(owner);
                        }
                        else
                        {
                            throw new PaymentException();
                        }



                        trans.Commit();
                        msg = new Message
                        {
                            Errorcode = Constants.ERROR_CODE_00,
                            ErrorMessage = Constants.ERROR_MSG_00
                        };
                    }
                    catch (OwnerNotFoundException)
                    {
                        trans.Rollback();
                        msg = new Message
                        {
                            Errorcode = Constants.ERROR_CODE_01,
                            ErrorMessage = Constants.ERROR_MSG_01
                        };
                    }
                    catch (PaymentException )
                    {
                        trans.Rollback();
                        msg = new Message
                        {
                            Errorcode = Constants.ERROR_CODE_88,
                            ErrorMessage = Constants.ERROR_MSG_88
                        };
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        msg = new Message
                        {
                            Errorcode = Constants.ERROR_CODE_99,
                            ErrorMessage = Constants.ERROR_MSG_99
                        };
                    }
                }
                session.Close();
            }

            return msg;
        }


    }



}