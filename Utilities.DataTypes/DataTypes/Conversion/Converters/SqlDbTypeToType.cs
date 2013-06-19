﻿/*
Copyright (c) 2012 <a href="http://www.gutgames.com">James Craig</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Utilities.DataTypes.Conversion.Interfaces;
using Utilities.DataTypes.Formatters;
using Utilities.DataTypes.Formatters.Interfaces;
#endregion

namespace Utilities.DataTypes.Conversion.Converters
{
    /// <summary>
    /// SqlDbType to Type Converter
    /// </summary>
    public class SqlDbTypeToType : Utilities.DataTypes.Conversion.ConverterBase<SqlDbType, Type>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Manager">Manager object</param>
        public SqlDbTypeToType(Manager Manager) : base(Manager) { }

        /// <summary>
        /// Converts the object to the specified type
        /// </summary>
        /// <param name="Item">Object to convert</param>
        /// <param name="ReturnType">Return type</param>
        /// <returns>The object as the type specified</returns>
        public override object To(SqlDbType Item, Type ReturnType)
        {
            SqlParameter Parameter = new SqlParameter();
            Parameter.SqlDbType = Item;
            return Parameter.DbType;
        }

        /// <summary>
        /// Converts the object to the specified type
        /// </summary>
        /// <param name="Item">Object to convert</param>
        /// <param name="ReturnType">Return type</param>
        /// <returns>The object as the type specified</returns>
        public override object To(Type Item, Type ReturnType)
        {
            SqlParameter Parameter = new SqlParameter();
            Parameter.DbType = Manager.To<Type, DbType>(Item);
            return Parameter.SqlDbType;
        }
    }
}