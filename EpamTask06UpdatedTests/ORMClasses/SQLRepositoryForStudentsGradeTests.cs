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
    /// The Class which test CRUD of ORM class for StudentsGrade
    /// </summary>
    [TestClass()]
    public class SQLRepositoryForStudentsGradeTests
    {
        IRepository<StudentsGrade> repository = SQLRepositoryForStudentsGrade.Repository;


        IRepository<Subject> repositoryForSubject = SQLRepositoryForSubject.Repository;

        IRepository<Session> repositoryForSession = SQLRepositoryForSession.Repository;

        IRepository<Speciality> repositoryForSpeciality = SQLRepositoryForSpeciality.Repository;

        IRepository<Group> repositoryForGroup = SQLRepositoryForGroup.Repository;

        IRepository<Student> repositoryForStudent = SQLRepositoryForStudent.Repository;

        IRepository<Teacher> repositoryForTeacher = SQLRepositoryForTeacher.Repository;


        [TestMethod()]
        public void CreateAndDeleteTest()
        {
            //arrange
            Subject subject = new Subject("Test Subject",0,0);
            Session session = new Session("Test Session",DateTime.MinValue,DateTime.MaxValue);
            Speciality speciality = new Speciality("TS","Test Speciality");
            Group group = new Group(1, 1,speciality);
            Student student = new Student("Test Student",DateTime.Now,group,Gender.Male);
            Teacher teacher = new Teacher("Test Teacher",DateTime.Now,Gender.Male);

            StudentsGrade studentsGrade = new StudentsGrade(9,student,subject,session,teacher);
            bool result;

            //act
            repositoryForSubject.Create(subject);
            repositoryForSession.Create(session);
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repositoryForStudent.Create(student);
            repositoryForTeacher.Create(teacher);

            repository.Create(studentsGrade);

            result = CheckExistance(studentsGrade);

            repository.Delete(GetID(studentsGrade));

            result = result && !CheckExistance(studentsGrade);

            repositoryForStudent.Delete(GetID(student));
            repositoryForGroup.Delete(GetID(group));
            repositoryForSubject.Delete(GetID(subject));
            repositoryForSpeciality.Delete(GetID(speciality));
            repositoryForSession.Delete(GetID(session));
            repositoryForTeacher.Delete(GetID(teacher));


            //assert
            Assert.IsTrue(result);
        }


        [TestMethod()]
        public void GetCollectionTest()
        {
            //arrange
            var grades = repository.GetCollection();

            //assert
            Assert.IsTrue(grades.All(grade => CheckExistance(grade)));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void ReadTest(int idValue)
        {
            //arrange
            StudentsGrade grade = repository.Read(idValue);

            //assert
            Assert.IsTrue(CheckExistance(grade));
        }

        [TestMethod()]
        public void UpdateAndDeleteTest()
        {
            //arrange
            Subject subject = new Subject("Test Subject", 0, 0);
            Session session = new Session("Test Session", DateTime.MinValue, DateTime.MaxValue);
            Speciality speciality = new Speciality("TS", "Test Speciality");
            Group group = new Group(1, 1, speciality);
            Student student = new Student("Test Student", DateTime.Now, group, Gender.Male);
            Teacher teacher = new Teacher("Test Teacher", DateTime.Now, Gender.Male);

            StudentsGrade studentsGrade = new StudentsGrade(9, student, subject, session, teacher);
            bool result;

            //act
            repositoryForSubject.Create(subject);
            repositoryForSession.Create(session);
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repositoryForStudent.Create(student);
            repositoryForTeacher.Create(teacher);

            repository.Create(studentsGrade);

            result = CheckExistance(studentsGrade);

            studentsGrade.Id = GetID(studentsGrade);

            studentsGrade.Grade = 10;

            repository.Update(studentsGrade);

            result = result && CheckExistance(studentsGrade);

            repository.Delete(studentsGrade.Id);

            repositoryForStudent.Delete(GetID(student));
            repositoryForGroup.Delete(GetID(group));
            repositoryForSubject.Delete(GetID(subject));
            repositoryForSpeciality.Delete(GetID(speciality));
            repositoryForSession.Delete(GetID(session));
            repositoryForTeacher.Delete(GetID(teacher));



            //assert
            Assert.IsTrue(result);
        }


    }
}