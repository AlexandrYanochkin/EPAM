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
    /// The Class which test CRUD of ORM class for Student
    /// </summary>
    [TestClass()]
    public class SQLRepositoryForStudentTests
    {
        IRepository<Student> repository = SQLRepositoryForStudent.Repository;

        IRepository<Group> repositoryForGroup = SQLRepositoryForGroup.Repository;

        IRepository<Speciality> repositoryForSpeciality = SQLRepositoryForSpeciality.Repository;


        [TestMethod()]
        public void CreateAndDeleteTest()
        {
            //arrange
            Speciality speciality = new Speciality("TS", "Test Speciality");
            Group group = new Group(1,1,speciality);
            Student student = new Student("Test Student", DateTime.Now, group, Gender.Male);
            bool result;

            //act
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repository.Create(student);

            result = CheckExistance(student);


            repository.Delete(GetID(student));         
            repositoryForGroup.Delete(GetID(group));
            repositoryForSpeciality.Delete(GetID(speciality));

            result = result && !CheckExistance(student);

            //assert
            Assert.IsTrue(result);
        }

     
        [TestMethod()]
        public void GetCollectionTest()
        {
            //arrange
            var students = repository.GetCollection();

            //assert
            Assert.IsTrue(students.All(student => CheckExistance(student)));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void ReadTest(int idValue)
        {
            //arrange
            Student student = repository.Read(idValue);

            //assert
            Assert.IsTrue(CheckExistance(student));
        }


        [TestMethod()]
        public void UpdateAndDeleteTest()
        {
            //arrange
            Speciality speciality = new Speciality("TS", "Test Speciality");
            Group group = new Group(1, 1, speciality);
            Student student = new Student("Test Student", DateTime.Now, group, Gender.Male);
            bool result;

            //act
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repository.Create(student);

            result = CheckExistance(student);
            student.Id = GetID(student);

            student.FullName = "Change Test";

            repository.Update(student);

            result = result && CheckExistance(student);

            repository.Delete(GetID(student));
            repositoryForGroup.Delete(GetID(group));
            repositoryForSpeciality.Delete(GetID(speciality));


            //assert
            Assert.IsTrue(result);
        }

    }
}