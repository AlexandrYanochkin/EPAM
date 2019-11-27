﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.ClassesOfShapes
{
    public class FilmEquilateralTriangle : AbstractEquilateralTriangle
    {
        public FilmEquilateralTriangle(double side) : base(side)
        {
        }

        public FilmEquilateralTriangle() : base()
        {
        }

        public FilmEquilateralTriangle(double side,AbstractShape shape) : base(side,shape)
        {
        } 

    }
}
