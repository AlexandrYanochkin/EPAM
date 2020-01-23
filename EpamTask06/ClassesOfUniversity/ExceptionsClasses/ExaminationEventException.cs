﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity.ExceptionsClasses
{
    public class ExaminationEventException : UniversityException
    {
        public ExaminationEventException() : base()
        {
        }

        public ExaminationEventException(string message) : base(message)
        {
        }

    }
}