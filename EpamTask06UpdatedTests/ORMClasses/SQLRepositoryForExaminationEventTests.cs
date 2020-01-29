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
    /// The Class which test CRUD of ORM class for Examination Events
    /// </summary>
    [TestClass()]
    public class SQLRepositoryForExaminationEventTests
    {
        IRepository<ExaminationEvent> repository = SQLRepositoryForExaminationEvent.Repository;


        IRepository<Subject> repositoryForSubject = SQLRepositoryForSubject.Repository;

        IRepository<Speciality> repositoryForSpeciality = SQLRepositoryForSpeciality.Repository;

        IRepository<Group> repositoryForGroup = SQLRepositoryForGroup.Repository;

        IRepository<Session> repositoryForSession = SQLRepositoryForSession.Repository;

        IRepository<Teacher> repositoryForTeacher = SQLRepositoryForTeacher.Repository;


        [TestMethod()]
        public void CreateAndDeleteTest()
        {
            //arrange
            Subject subject = new Subject("Test Subject", 0, 0);
            Speciality speciality = new Speciality("TS", "Test Speciality");
            Group group = new Group(1, 1, speciality);
            Session session = new Session("TestSession", DateTime.MinValue, DateTime.MaxValue);
            Teacher teacher = new Teacher("TestTeacher", DateTime.Now, Gender.Male);

            ExaminationEvent examinationEvent = new ExaminationEvent(subject, group, DateTime.Now, ExaminationEventType.Exam, session,teacher);
            bool result;

            //act
            repositoryForSubject.Create(subject);
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repositoryForSession.Create(session);
            repositoryForTeacher.Create(teacher);


            repository.Create(examinationEvent);

            result = CheckExistance(examinationEvent);
            repository.Delete(GetID(examinationEvent));
            result = result && !CheckExistance(examinationEvent);

            repositoryForGroup.Delete(GetID(group));
            repositoryForSpeciality.Delete(GetID(speciality));
            repositoryForSubject.Delete(GetID(subject));
            repositoryForSession.Delete(GetID(session));
            repositoryForTeacher.Delete(GetID(teacher));


            //assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetCollectionTest()
        {
            //assert
            var examinationEvents = repository.GetCollection();

            //assert
            Assert.IsTrue(examinationEvents.All(examEvent => CheckExistance(examEvent)));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void ReadTest(int idValue)
        {
            //arrange
            ExaminationEvent examinationEvent = repository.Read(idValue);

            //assert
            Assert.IsTrue(CheckExistance(examinationEvent));
        }

        [TestMethod()]
        public void UpdateAndDeleteTest()
        {
            //arrange
            Subject subject = new Subject("Test Subject", 0, 0);
            Speciality speciality = new Speciality("TS", "Test Speciality");
            Group group = new Group(1, 1, speciality);
            Session session = new Session("TestSession", DateTime.MinValue, DateTime.MaxValue);
            Teacher teacher = new Teacher("TestTeacher", DateTime.Now, Gender.Male);

            ExaminationEvent examinationEvent = new ExaminationEvent(subject, group, DateTime.Now, ExaminationEventType.Exam, session, teacher);
            bool result;

            //act
            repositoryForSubject.Create(subject);
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repositoryForSession.Create(session);
            repositoryForTeacher.Create(teacher);


            repository.Create(examinationEvent);

            result = CheckExistance(examinationEvent);
            examinationEvent.Id = GetID(examinationEvent);

            examinationEvent.Date = DateTime.MaxValue;

            repository.Update(examinationEvent);

            result = result && CheckExistance(examinationEvent);

            repository.Delete(GetID(examinationEvent));

            repositoryForGroup.Delete(GetID(group));
            repositoryForSpeciality.Delete(GetID(speciality));
            repositoryForSubject.Delete(GetID(subject));
            repositoryForSession.Delete(GetID(session));
            repositoryForTeacher.Delete(GetID(teacher));


            //assert
            Assert.IsTrue(result);
        }

    }
}