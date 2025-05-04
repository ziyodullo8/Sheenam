//================================
//Copyright (C) Coalitionof Good-Hearted Engineers
//Free To Use Comfort and Peace
//================================

using System;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Exeptions
{
    public class NullGuestExceptions: Xeption
    {
        public NullGuestExceptions()
         : base(message: "Guest is null")
        { }
    }
}
