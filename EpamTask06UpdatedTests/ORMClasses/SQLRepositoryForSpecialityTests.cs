﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask06.ORMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask06.ClassesOfUniversity;
using static EpamTask06.ORMClasses.SQLWorker;

namespace EpamTask06.ORMClasses.Tests
{
    /// <summary>
    /// The Class which test CRUD of ORM class for Speciality
    /// </summary>
    [TestClass()]
    public class SQLRepositoryForSpecialityTests
    {
        IRepository<Speciality> repository = SQLRepositoryForSpeciality.Repository;


        [TestMethod()]
        public void CreateDeleteTest()
        {
            //arrange
            Speciality speciality = new Speciality("TS", "Test Speciality");
            bool result;

            //act
            repository.Create(speciality);
            result = CheckExistance(speciality);
            speciality.Id = GetID(speciality);

            repository.Delete(speciality.Id);
            result = result && !CheckExistance(speciality);

            //assert
            Assert.IsTrue(result);
        }


        [TestMethod()]
        public void GetCollectionTest()
        {
            //arrange
            var specialities = repository.GetCollection();

            //assert
            Assert.IsTrue(specialities.All(speciality => CheckExistance(speciality)));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public void ReadTest(int idValue)
        {
            //arrange 
            Speciality speciality = repository.Read(idValue);

            //assert
            Assert.IsTrue(CheckExistance(speciality));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            //arrange
            Speciality speciality = new Speciality("TS", "Test Speciality");
            bool result;

            //act
            repository.Create(speciality);
            result = CheckExistance(speciality);
            speciality.Id = GetID(speciality);
            speciality.NameOfSpeciality = "Test Change";
            repository.Update(speciality);
            result = result && CheckExistance(speciality);
            repository.Delete(speciality.Id);


            //assert
            Assert.IsTrue(result);
        }

    }
}