using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWebApp.IoC
{
  public class StructureMapControllerFactory : DefaultControllerFactory
  {
    //protected override IController GetControllerInstance(Type controllerType)
    //{
    //  if (controllerType == null) return null;
    //  try
    //  {
    //    return ObjectFactory.GetInstance(controllerType) as Controller;
    //  }
    //  catch (StructureMapException)
    //  {
    //    System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());
    //    throw;
    //  }
    //}
  }
}