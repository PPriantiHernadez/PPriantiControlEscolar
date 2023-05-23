﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlumno" in both code and config file together.
    [ServiceContract]
    public interface IAlumno
    {
        //Add
        [OperationContract]
        SL_WCF.Result Add(ML.Alumno alumno);

        //Update
        [OperationContract]
        SL_WCF.Result Update(ML.Alumno alumno);

        //Delete
        [OperationContract]
        SL_WCF.Result Delete(ML.Alumno alumno);

        //GetAll
        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        SL_WCF.Result GetAll();

        //GetById
        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        SL_WCF.Result GetById(int IdAlumno);

    }
}
