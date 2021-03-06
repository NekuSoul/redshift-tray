﻿using System.Diagnostics;
/* This file is part of redshift-tray.
   Redshift-tray is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.
   Redshift-tray is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.
   You should have received a copy of the GNU General Public License
   along with redshift-tray.  If not, see <http://www.gnu.org/licenses/>.
   Copyright (c) Michael Scholz <development@mischolz.de>
*/
using System.Linq;
using System.Windows;

namespace redshift_tray
{
  public partial class App : Application
  {

    void Main(object sender, StartupEventArgs e)
    {
      if(Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Count() > 1)
      {
        Application.Current.Shutdown(0);
      }
      else
      {
        bool dummyMethod = e.Args.Any(arg => (arg.ToLower() == "/dummy"));
        Main main = new Main(dummyMethod);

        if(!main.Initialize())
        {
          Application.Current.Shutdown(-1);
        }
      }
    }

  }
}
