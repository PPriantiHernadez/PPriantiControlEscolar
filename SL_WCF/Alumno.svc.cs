﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Alumno" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Alumno.svc or Alumno.svc.cs at the Solution Explorer and start debugging.
    public class Alumno : IAlumno
    {
        //Add
        public SL_WCF.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            result = BL.Alumno.Add(alumno);

            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };

        }

        //Update
        public SL_WCF.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            result = BL.Alumno.Update(alumno);
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };

        }

        //Delete
        public SL_WCF.Result Delete(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            result = BL.Alumno.Delete(alumno);
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };

        }

        //GetAll
        public SL_WCF.Result GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();

            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }

        //GetById
        public SL_WCF.Result GetById(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            result = BL.Alumno.GetById(IdAlumno);
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
    }
}
