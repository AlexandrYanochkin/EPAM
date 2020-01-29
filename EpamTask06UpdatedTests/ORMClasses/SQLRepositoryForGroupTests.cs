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
    /// The Class which test CRUD of ORM class for Group
    /// </summary>
    [TestClass()]
    public class SQLRepositoryForGroupTests
    {
        IRepository<Group> repository = SQLRepositoryForGroup.Repository;

        IRepository<Speciality> repositoryForSpeciality = SQLRepositoryForSpeciality.Repository;

        [TestMethod()]
        public void CreateAndDeleteTest()
        {
            //arrange
            Speciality speciality = new Speciality("TS", "Test Speciality");
            Group group = new Group(1,1,speciality);
            bool result;

            //act
            repositoryForSpeciality.Create(speciality);
            repository.Create(group);

            result = CheckExistance(group);

            repository.Delete(GetID(group));
            repositoryForSpeciality.Delete(GetID(speciality));

            result = result && !CheckExistance(group);


            //assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetCollectionTest()
        {
            //arrange
            var groups = repository.GetCollection();

            //assert
            Assert.IsTrue(groups.All(group => CheckExistance(group)));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public void ReadTest(int idValue)
        {
            //arrange
            Group group = repository.Read(idValue);

            //assert
            Assert.IsTrue(CheckExistance(group));
        }

        [TestMethod()]
        public void UpdateAndDeleteTest()
        {
            //arrange
            Speciality speciality = new Speciality("TS", "Test Speciality");
            Group group = new Group(1, 1, speciality);
            bool result;

            //act
            repositoryForSpeciality.Create(speciality);
            repository.Create(group);
            result = CheckExistance(group);
            group.Id = GetID(group);
            group.NumOfCourse++;
            group.NumOfGroup++;
            repository.Update(group);
            result = result && CheckExistance(group);
            repository.Delete(group.Id);
            repositoryForSpeciality.Delete(GetID(speciality));

           
            //assert
            Assert.IsTrue(result);
        }


    }
}