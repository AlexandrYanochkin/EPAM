﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity.ExceptionsClasses
{
    public class SessionResultsException : UniversityException
    {
        public SessionResultsException() : base()
        {

        }

        public SessionResultsException(string message) : base(message)
        {

        }

    }
}